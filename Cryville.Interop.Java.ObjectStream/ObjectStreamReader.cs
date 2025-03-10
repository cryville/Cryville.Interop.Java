using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Cryville.Interop.Java.ObjectStream {
	public class ObjectStreamReader : IDisposable {
		readonly Stream _stream;
		readonly bool _leaveOpen;

		public ObjectStreamReader(Stream stream, bool leaveOpen = false) {
			_stream = stream;
			_leaveOpen = leaveOpen;
			if (ReadUInt16() != Shared.MAGIC) throw new FormatException("Invalid object stream.");
			if (ReadUInt16() != Shared.VERSION) throw new NotImplementedException();
		}

		private int _disposed;
		protected virtual void Dispose(bool disposing) {
			if (Interlocked.Exchange(ref _disposed, 1) != 0) return;
			if (!disposing) return;
			if (!_leaveOpen) _stream.Dispose();
		}
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		readonly byte[] _buffer = new byte[8];
		readonly byte[] _utfBuffer = new byte[ushort.MaxValue];
		public void ReadExactly(Span<byte> buffer) {
#if NET7_0_OR_GREATER
			_stream.ReadExactly(buffer);
#else
			int num;
			for (int i = 0; i < buffer.Length; i += num) {
				num = _stream.Read(buffer[i..]);
				if (num == 0) throw new EndOfStreamException();
			}
#endif
		}
		byte ReadByte() {
			var result = _stream.ReadByte();
			if (result == -1) throw new EndOfStreamException();
			return (byte)result;
		}
		short ReadInt16() {
			ReadExactly(_buffer.AsSpan()[..sizeof(short)]);
			return BinaryPrimitives.ReadInt16BigEndian(_buffer);
		}
		ushort ReadUInt16() {
			ReadExactly(_buffer.AsSpan()[..sizeof(ushort)]);
			return BinaryPrimitives.ReadUInt16BigEndian(_buffer);
		}
		int ReadInt32() {
			ReadExactly(_buffer.AsSpan()[..sizeof(int)]);
			return BinaryPrimitives.ReadInt32BigEndian(_buffer);
		}
		long ReadInt64() {
			ReadExactly(_buffer.AsSpan()[..sizeof(long)]);
			return BinaryPrimitives.ReadInt64BigEndian(_buffer);
		}
		float ReadSingle() {
			ReadExactly(_buffer.AsSpan()[..sizeof(float)]);
#if NET5_0_OR_GREATER
			return BinaryPrimitives.ReadSingleBigEndian(_buffer);
#else
			return BitConverter.IsLittleEndian ?
				BitConverter.Int32BitsToSingle(BinaryPrimitives.ReverseEndianness(MemoryMarshal.Read<int>(_buffer))) :
				MemoryMarshal.Read<float>(_buffer);
#endif
		}
		double ReadDouble() {
			ReadExactly(_buffer.AsSpan()[..sizeof(double)]);
#if NET5_0_OR_GREATER
			return BinaryPrimitives.ReadDoubleBigEndian(_buffer);
#else
			return BitConverter.IsLittleEndian ?
				BitConverter.Int64BitsToDouble(BinaryPrimitives.ReverseEndianness(MemoryMarshal.Read<long>(_buffer))) :
				MemoryMarshal.Read<double>(_buffer);
#endif
		}
		string ReadUtf() {
			var len = ReadUInt16();
			ReadExactly(_utfBuffer.AsSpan()[..len]);
			return Shared.Encoding.GetString(_utfBuffer.AsSpan()[..len]);
		}

		readonly List<object> _handles = [];
		void AssignNewHandle(object value) {
			_handles.Add(value);
		}
		object ReadPrevObjectCore() {
			return _handles[ReadInt32() - Shared.BaseWireHandle];
		}
		SerializedObjectStreamReset ReadResetCore() {
			_handles.Clear();
			return SerializedObjectStreamReset.Instance;
		}

		public object? ReadContent() {
			return ReadContentInternal(ReadByte());
		}

		object? ReadContentInternal(byte type) {
			return type switch {
				Shared.TC_OBJECT => ReadJavaObjectCore(),
				Shared.TC_CLASS => throw new NotImplementedException(),
				Shared.TC_ARRAY => throw new NotImplementedException(),
				Shared.TC_STRING => ReadStringCore(),
				Shared.TC_LONGSTRING => throw new NotImplementedException(),
				Shared.TC_ENUM => throw new NotImplementedException(),
				Shared.TC_CLASSDESC => ReadClassDescCore(),
				Shared.TC_PROXYCLASSDESC => throw new NotImplementedException(),
				Shared.TC_REFERENCE => ReadPrevObjectCore(),
				Shared.TC_NULL => null,
				Shared.TC_EXCEPTION => throw new NotImplementedException(),
				Shared.TC_RESET => ReadResetCore(),
				Shared.TC_BLOCKDATA => ReadBlockDataCore(),
				Shared.TC_BLOCKDATALONG => throw new NotImplementedException(),
				_ => throw new FormatException(),
			};
		}

		public SerializedJavaObject ReadJavaObjectCore() {
			var classDesc = ReadClassDesc() ?? throw new FormatException();
			var result = new SerializedJavaObject {
				ClassDesc = classDesc,
			};
			AssignNewHandle(result);
			var flags = classDesc.ClassDescFlags;
			if (flags.HasFlag(JavaClassDescFlags.Serializable)) {
				foreach (var field in classDesc.Fields) {
					result.Values.Add(ReadClassData(field));
				}
				if (flags.HasFlag(JavaClassDescFlags.WriteMethod)) {
					while (true) {
						var type = ReadByte();
						if (type == Shared.TC_ENDBLOCKDATA) break;
						result.ObjectAnnotation.Add(ReadContentInternal(type));
					}
				}
			}
			else if (flags.HasFlag(JavaClassDescFlags.Externalizable)) {
				throw new NotImplementedException();
			}
			else throw new FormatException();
			return result;
		}

		public SerializedJavaClassDesc? ReadClassDesc() {
			return ReadByte() switch {
				Shared.TC_CLASSDESC => ReadClassDescCore(),
				Shared.TC_PROXYCLASSDESC => throw new NotImplementedException(),
				Shared.TC_NULL => null,
				Shared.TC_REFERENCE => (SerializedJavaClassDesc)ReadPrevObjectCore(),
				_ => throw new FormatException(),
			};
		}

		public SerializedJavaClassDesc ReadClassDescCore() {
			var result = new SerializedJavaClassDesc(ReadUtf()) {
				SerialVersionUID = ReadInt64(),
			};
			AssignNewHandle(result);
			result.ClassDescFlags = (JavaClassDescFlags)ReadByte();
			var fieldCount = ReadInt16();
			for (int i = 0; i < fieldCount; i++) {
				var typecode = ReadByte();
				result.Fields.Add(typecode switch {
					0x42 or 0x43 or 0x44 or 0x46 or 0x49 or 0x4a or 0x53 or 0x5a => new SerializedJavaPrimitiveField(
						ReadUtf(),
						(JavaPrimitiveType)typecode
					),
					0x5b or 0x4c => new SerializedJavaObjectField(
						ReadUtf(),
						typecode is 0x5b,
						(string)(ReadContent() ?? throw new FormatException())
					),
					_ => throw new FormatException(),
				});
			}
			while (true) {
				var type = ReadByte();
				if (type == Shared.TC_ENDBLOCKDATA) break;
				result.ClassAnnotation.Add(ReadContentInternal(type));
			}
			result.SuperClass = ReadClassDesc();
			return result;
		}

		public object? ReadClassData(SerializedJavaField field) {
			return field switch {
				SerializedJavaPrimitiveField pf => pf.Type switch {
					JavaPrimitiveType.Byte => ReadByte(),
					JavaPrimitiveType.Char => throw new NotImplementedException(),
					JavaPrimitiveType.Double => ReadDouble(),
					JavaPrimitiveType.Float => ReadSingle(),
					JavaPrimitiveType.Integer => ReadInt32(),
					JavaPrimitiveType.Long => ReadInt64(),
					JavaPrimitiveType.Short => ReadInt16(),
					JavaPrimitiveType.Boolean => ReadByte() != 0,
					_ => throw new FormatException(),
				},
				SerializedJavaObjectField => ReadContent(),
				_ => throw new FormatException(),
			};
		}

		public string ReadStringCore() {
			var result = ReadUtf();
			AssignNewHandle(result);
			return result;
		}

		public byte[] ReadBlockDataCore() {
			var len = ReadByte();
			var result = new byte[len];
			ReadExactly(result);
			return result;
		}
	}
}

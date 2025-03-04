using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Cryville.Interop.Java.ObjectStream {
	public class ObjectStreamWriter : IDisposable {
		readonly BinaryWriter _writer;
		readonly bool _leaveOpen;

		public ObjectStreamWriter(Stream stream, bool leaveOpen = false) {
			_writer = new BinaryWriter(stream);
			_leaveOpen = leaveOpen;
			Write(Shared.MAGIC);
			Write(Shared.VERSION);
		}

		private int _disposed;
		protected virtual void Dispose(bool disposing) {
			if (Interlocked.Exchange(ref _disposed, 1) != 0) return;
			if (!disposing) return;
			if (!_leaveOpen) _writer.Close();
		}
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		readonly byte[] _buffer = new byte[8];
		readonly byte[] _utfBuffer = new byte[ushort.MaxValue];
		void Write(byte value) => _writer.Write(value);
		void Write(short value) {
			BinaryPrimitives.WriteInt16BigEndian(_buffer, value);
			_writer.Write(_buffer.AsSpan()[..sizeof(short)]);
		}
		void Write(ushort value) {
			BinaryPrimitives.WriteUInt16BigEndian(_buffer, value);
			_writer.Write(_buffer.AsSpan()[..sizeof(ushort)]);
		}
		void Write(int value) {
			BinaryPrimitives.WriteInt32BigEndian(_buffer, value);
			_writer.Write(_buffer.AsSpan()[..sizeof(int)]);
		}
		void Write(long value) {
			BinaryPrimitives.WriteInt64BigEndian(_buffer, value);
			_writer.Write(_buffer.AsSpan()[..sizeof(long)]);
		}
		void Write(ReadOnlySpan<byte> value) => _writer.Write(value);
		void WriteUtf(string value) {
			var len = Shared.Encoding.GetBytes(value, _utfBuffer);
			Write((ushort)len);
			Write(_utfBuffer.AsSpan()[..len]);
		}

		readonly Dictionary<object, int> _handles = [];
		void AssignNewHandle(object value) {
			_handles.Add(value, Shared.BaseWireHandle + _handles.Count);
		}
		bool WritePrevObject(object value) {
			if (_handles.TryGetValue(value, out var handle)) {
				Write(Shared.TC_REFERENCE);
				Write(handle);
				return true;
			}
			return false;
		}
		public void Reset() {
			_handles.Clear();
			Write(Shared.TC_RESET);
		}

		public void Write(SerializedJavaContent? value) {
			if (value is null) { Write(Shared.TC_NULL); return; }
			if (WritePrevObject(value)) return;
			if (value is SerializedJavaObject obj) Write(obj);
			else if (value is SerializedJavaClassDesc cd) Write(cd);
			else {
				throw new NotImplementedException();
			}
			_writer.Flush();
		}

		public void Write(SerializedJavaObject? value) {
			if (value is null) { Write(Shared.TC_NULL); return; }
			if (WritePrevObject(value)) return;
			Write(Shared.TC_OBJECT);
			Write(value.ClassDesc);
			AssignNewHandle(value);
			foreach (var data in value.Values) {
				if (data is int i) Write(i);
				else if (data is bool z) Write(z ? (byte)1 : (byte)0);
				else if (data is SerializedJavaContent c) Write(c);
				else throw new NotImplementedException();
			}
		}

		public void Write(SerializedJavaClassDesc? value) {
			if (value is null) { Write(Shared.TC_NULL); return; }
			if (WritePrevObject(value)) return;
			Write(Shared.TC_CLASSDESC);
			WriteUtf(value.Name);
			Write(value.SerialVersionUID);
			AssignNewHandle(value);
			Write((byte)value.ClassDescFlags);
			Write((short)value.Fields.Count);
			foreach (var field in value.Fields) {
				if (field is SerializedJavaPrimitiveField pf) {
					Write((byte)pf.Type);
					WriteUtf(pf.Name);
				}
				else if (field is SerializedJavaObjectField of) {
					Write(of.IsArray ? (byte)0x5b : (byte)0x4c);
					WriteUtf(of.Name);
					Write(of.ClassName);
				}
			}
			foreach (var annotation in value.ClassAnnotation) {
				Write((SerializedJavaContent?)annotation);
			}
			Write(Shared.TC_ENDBLOCKDATA);
			Write(value.SuperClass);
			_writer.Flush();
		}

		public void Write(string value) {
			if (WritePrevObject(value)) return;
			Write(Shared.TC_STRING); // TODO long string
			AssignNewHandle(value);
			WriteUtf(value);
			_writer.Flush();
		}
	}
}

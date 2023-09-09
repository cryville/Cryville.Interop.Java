using System;
using System.Runtime.InteropServices;
using UnsafeIL;

namespace Cryville.Interop.Java {
	/// <summary>
	/// JNI value.
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct JniValue : IEquatable<JniValue> {
		[FieldOffset(0)]
		private bool z;

		[FieldOffset(0)]
		private sbyte b;

		[FieldOffset(0)]
		private char c;

		[FieldOffset(0)]
		private short s;

		[FieldOffset(0)]
		private int i;

		[FieldOffset(0)]
		private long j;

		[FieldOffset(0)]
		private float f;

		[FieldOffset(0)]
		private double d;

		[FieldOffset(0)]
		private IntPtr l;

		/// <summary>
		/// Creates an instance of the <see cref="JniValue" /> struct with a <see cref="bool" /> (<c>boolean</c> in Java) value.
		/// </summary>
		/// <param name="value">The value.</param>
		public JniValue(bool value) {
			Unsafe.SkipInit(out this);
			z = value;
		}

		/// <summary>
		/// Creates an instance of the <see cref="JniValue" /> struct with a <see cref="sbyte" /> (<c>byte</c> in Java) value.
		/// </summary>
		/// <param name="value">The value.</param>
		public JniValue(sbyte value) {
			Unsafe.SkipInit(out this);
			b = value;
		}

		/// <summary>
		/// Creates an instance of the <see cref="JniValue" /> struct with a <see cref="byte" /> (casted to <see cref="sbyte" />, <c>byte</c> in Java) value.
		/// </summary>
		/// <param name="value">The value.</param>
		public JniValue(byte value) : this((sbyte)value) { }

		/// <summary>
		/// Creates an instance of the <see cref="JniValue" /> struct with a <see cref="char" /> (<c>char</c> in Java) value.
		/// </summary>
		/// <param name="value">The value.</param>
		public JniValue(char value) {
			Unsafe.SkipInit(out this);
			c = value;
		}

		/// <summary>
		/// Creates an instance of the <see cref="JniValue" /> struct with a <see cref="short" /> (<c>short</c> in Java) value.
		/// </summary>
		/// <param name="value">The value.</param>
		public JniValue(short value) {
			Unsafe.SkipInit(out this);
			s = value;
		}

		/// <summary>
		/// Creates an instance of the <see cref="JniValue" /> struct with a <see cref="ushort" /> (casted to <see cref="short" />, <c>short</c> in Java) value.
		/// </summary>
		/// <param name="value">The value.</param>
		public JniValue(ushort value) : this((short)value) { }

		/// <summary>
		/// Creates an instance of the <see cref="JniValue" /> struct with a <see cref="int" /> (<c>int</c> in Java) value.
		/// </summary>
		/// <param name="value">The value.</param>
		public JniValue(int value) {
			Unsafe.SkipInit(out this);
			i = value;
		}

		/// <summary>
		/// Creates an instance of the <see cref="JniValue" /> struct with a <see cref="uint" /> (casted to <see cref="int" />, <c>int</c> in Java) value.
		/// </summary>
		/// <param name="value">The value.</param>
		public JniValue(uint value) : this((int)value) { }

		/// <summary>
		/// Creates an instance of the <see cref="JniValue" /> struct with a <see cref="long" /> (<c>long</c> in Java) value.
		/// </summary>
		/// <param name="value">The value.</param>
		public JniValue(long value) {
			Unsafe.SkipInit(out this);
			j = value;
		}

		/// <summary>
		/// Creates an instance of the <see cref="JniValue" /> struct with a <see cref="ulong" /> (casted to <see cref="long" />, <c>long</c> in Java) value.
		/// </summary>
		/// <param name="value">The value.</param>
		public JniValue(ulong value) : this((long)value) { }

		/// <summary>
		/// Creates an instance of the <see cref="JniValue" /> struct with a <see cref="float" /> (<c>float</c> in Java) value.
		/// </summary>
		/// <param name="value">The value.</param>
		public JniValue(float value) {
			Unsafe.SkipInit(out this);
			f = value;
		}

		/// <summary>
		/// Creates an instance of the <see cref="JniValue" /> struct with a <see cref="double" /> (<c>double</c> in Java) value.
		/// </summary>
		/// <param name="value">The value.</param>
		public JniValue(double value) {
			Unsafe.SkipInit(out this);
			d = value;
		}

		/// <summary>
		/// Creates an instance of the <see cref="JniValue" /> struct with a <see cref="IntPtr" /> to an object (<c>java.lang.Object</c> in Java).
		/// </summary>
		/// <param name="value">The value.</param>
		public JniValue(IntPtr value) {
			Unsafe.SkipInit(out this);
			l = value;
		}

		/// <inheritdoc />
		public override int GetHashCode() {
			return j.GetHashCode();
		}

		/// <inheritdoc />
		public override bool Equals(object obj) {
			JniValue? o = obj as JniValue?;
			if (!o.HasValue) return false;
			return Equals(o.Value);
		}

		/// <inheritdoc />
		public bool Equals(JniValue other) {
			return j == other.j;
		}

		/// <inheritdoc />
		public static bool operator ==(JniValue lhs, JniValue rhs) {
			return lhs.j == rhs.j;
		}

		/// <inheritdoc />
		public static bool operator !=(JniValue lhs, JniValue rhs) {
			return lhs.j != rhs.j;
		}

		/// <inheritdoc />
		public override string ToString() {
			return string.Format("JniValue(z={0},b={1},c={2},s={3},i={4},j={5},f={6},d={7},l=0x{8})", z, b, c, s, i, j, f, d, l.ToString("x"));
		}
	}
}

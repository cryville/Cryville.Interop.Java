using System;

namespace Cryville.Interop.Java {
	/// <summary>
	/// JNI native method.
	/// </summary>
	public struct JniNativeMethod {
		/// <summary>
		/// The name of the native method.
		/// </summary>
		public string Name;
		/// <summary>
		/// The signature of the native method.
		/// </summary>
		public string Signature;
		/// <summary>
		/// The function pointer of the native method.
		/// </summary>
		/// <remarks>
		/// <para>The function pointers nominally must have the following signature:</para>
		/// <code>ReturnType function(IntPtr env, IntPtr objectOrClass, ...)</code>
		/// </remarks>
		public Delegate FunctionPointer;

		/// <summary>
		/// Creates an instance of the <see cref="JniNativeMethod" /> struct.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="signature">The signature.</param>
		/// <param name="functionPointer">The function pointer.</param>
		/// <exception cref="ArgumentNullException">Either of the arguments is <see langword="null" />.</exception>
		public JniNativeMethod(string name, string signature, Delegate functionPointer) {
			Name = name ?? throw new ArgumentNullException(nameof(name));
			Signature = signature ?? throw new ArgumentNullException(nameof(signature));
			FunctionPointer = functionPointer ?? throw new ArgumentNullException(nameof(functionPointer));
		}
	}
}

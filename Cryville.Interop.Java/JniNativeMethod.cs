using System;

namespace Cryville.Interop.Java {
	/// <summary>
	/// JNI native method.
	/// </summary>
	/// <param name="Name">The name of the native method.</param>
	/// <param name="Signature">The signature of the native method.</param>
	/// <param name="FunctionPointer">The function pointer of the native method.</param>
	/// <exception cref="ArgumentNullException">Either of the arguments is <see langword="null" />.</exception>
	/// <remarks>
	/// <para>The function pointers nominally must have the following signature:</para>
	/// <code>ReturnType function(IntPtr env, IntPtr objectOrClass, ...)</code>
	/// </remarks>
	public record struct JniNativeMethod(string Name, string Signature, Delegate FunctionPointer);
}

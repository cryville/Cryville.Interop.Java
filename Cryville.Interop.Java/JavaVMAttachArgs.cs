using System;

namespace Cryville.Interop.Java {
	/// <summary>
	/// Additional information for attaching the current thread to a Java VM.
	/// </summary>
	/// <remarks>
	/// Creates an instance of the <see cref="JavaVMAttachArgs" /> struct.
	/// </remarks>
	/// <param name="Version">The requested JNI version.</param>
	/// <param name="Name">The name of the thread, or <see langword="null" />.</param>
	/// <param name="Group">Global ref of a <c>ThreadGroup</c> object, or <see cref="IntPtr.Zero" />.</param>
	public record struct JavaVMAttachArgs(int Version, string Name, IntPtr Group);
}

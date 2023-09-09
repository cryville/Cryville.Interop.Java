using System;

namespace Cryville.Interop.Java {
	/// <summary>
	/// Additional information for attaching the current thread to a Java VM.
	/// </summary>
	public struct JavaVMAttachArgs {
		/// <summary>
		/// The requested JNI version.
		/// </summary>
		public int Version;
		/// <summary>
		/// The name of the thread, or <see langword="null" />.
		/// </summary>
		public string Name;
		/// <summary>
		/// Global ref of a <c>ThreadGroup</c> object, or <see cref="IntPtr.Zero" />.
		/// </summary>
		public IntPtr Group;

		/// <summary>
		/// Creates an instance of the <see cref="JavaVMAttachArgs" /> struct.
		/// </summary>
		/// <param name="version">The requested JNI version.</param>
		/// <param name="name">The name of the thread.</param>
		/// <param name="group">Global ref of a <c>ThreadGroup</c> object.</param>
		public JavaVMAttachArgs(int version, string name, IntPtr group) {
			Version = version;
			Name = name;
			Group = group;
		}
	}
}
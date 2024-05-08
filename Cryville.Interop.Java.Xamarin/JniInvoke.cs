using Java.Interop;
using System;

namespace Cryville.Interop.Java.Xamarin {
	/// <summary>
	/// The Xamarin JNI Invocation API.
	/// </summary>
	/// <remarks>
	/// <para><see cref="AttachCurrentThreadAsDaemon(JavaVMAttachArgs?)" /> is not implemented.</para>
	/// <para><see cref="DetachCurrentThread" /> does nothing.</para>
	/// <para><see cref="GetEnv(int)" /> always succeeds.</para>
	/// </remarks>
	public class JniInvoke : IJniInvoke {
		static JniInvoke? m_instance;
		/// <summary>
		/// An instance of the <see cref="JniInvoke" /> singleton class.
		/// </summary>
		public static JniInvoke Instance => m_instance ??= new JniInvoke();
		JniInvoke() { }

		/// <inheritdoc />
		public IJniEnv AttachCurrentThread(JavaVMAttachArgs? thrArgs) {
			string? name = null;
			IntPtr group = default;
			if (thrArgs is JavaVMAttachArgs args) {
				name = args.Name;
				group = args.Group;
			}
			try {
				JniRuntime.CurrentRuntime.AttachCurrentThread(name, group == default ? default : new JniObjectReference(group));
			}
			catch (NotSupportedException ex) {
				throw new JniException("AttachCurrentThread failed.", ex);
			}
			return JniEnv.Instance;
		}
		/// <inheritdoc />
		public IJniEnv AttachCurrentThreadAsDaemon(JavaVMAttachArgs? args) => throw new NotImplementedException();
		/// <inheritdoc />
		public void DestroyJavaVM() => JniRuntime.CurrentRuntime.DestroyRuntime();
		/// <inheritdoc />
		public void DetachCurrentThread() { }
		/// <inheritdoc />
		public IJniEnv GetEnv(int version) => JniEnv.Instance;
	}
}

using Java.Interop;
using System;

namespace Cryville.Interop.Java.Xamarin {
	/// <summary>
	/// The Xamarin JNI Invocation API.
	/// </summary>
	/// <remarks>
	/// <para><see cref="AttachCurrentThreadAsDaemon(out IJniEnv, JavaVMAttachArgs?)" /> and <see cref="DetachCurrentThread" /> are not implemented.</para>
	/// <para><see cref="GetEnv(out IJniEnv, int)" /> always succeeds.</para>
	/// </remarks>
	public class JniInvoke : IJniInvoke {
		static JniInvoke m_instance;
		/// <summary>
		/// An instance of the <see cref="JniInvoke" /> singleton class.
		/// </summary>
		public static JniInvoke Instance {
			get {
				if (m_instance == null)
					m_instance = new JniInvoke();
				return m_instance;
			}
		}
		JniInvoke() { }

		/// <inheritdoc />
		public JniResult AttachCurrentThread(out IJniEnv p_env, JavaVMAttachArgs? thr_args) {
			string name = null;
			IntPtr group = default;
			if (thr_args is JavaVMAttachArgs args) {
				name = args.Name;
				group = args.Group;
			}
			JniRuntime.CurrentRuntime.AttachCurrentThread(name, group == default ? default : new JniObjectReference(group));
			p_env = JniEnv.Instance;
			return JniResult.OK;
		}
		/// <inheritdoc />
		public JniResult AttachCurrentThreadAsDaemon(out IJniEnv penv, JavaVMAttachArgs? args) => throw new NotImplementedException();
		/// <inheritdoc />
		public JniResult DestroyJavaVM() {
			JniRuntime.CurrentRuntime.DestroyRuntime();
			return JniResult.OK;
		}
		/// <inheritdoc />
		public JniResult DetachCurrentThread() => throw new NotImplementedException();
		/// <inheritdoc />
		public JniResult GetEnv(out IJniEnv env, int version) {
			env = JniEnv.Instance;
			return JniResult.OK;
		}
	}
}
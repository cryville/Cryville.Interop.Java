using System;
using UnityEngine;

namespace Cryville.Interop.Java.Unity {
	/// <summary>
	/// The Unity JNI Invocation API.
	/// </summary>
	/// <remarks>
	/// <para><see cref="AttachCurrentThreadAsDaemon(out IJniEnv, JavaVMAttachArgs?)" /> and <see cref="DestroyJavaVM" /> are not implemented.</para>
	/// <para>All parameters of type <see cref="JavaVMAttachArgs" /> are not supported and ignored.</para>
	/// <para><see cref="GetEnv(out IJniEnv, int)" /> always succeeds.</para>
	/// </remarks>
	public class JniInvoke : IJniInvoke {
		static JniInvoke m_instance;
		public static JniInvoke Instance {
			get {
				if (m_instance == null)
					m_instance = new JniInvoke();
				return m_instance;
			}
		}
		JniInvoke() { }

		public JniResult AttachCurrentThread(out IJniEnv p_env, JavaVMAttachArgs? thr_args) {
			p_env = JniEnv.Instance;
			return (JniResult)AndroidJNI.AttachCurrentThread();
		}
		public JniResult AttachCurrentThreadAsDaemon(out IJniEnv penv, JavaVMAttachArgs? args) => throw new NotImplementedException();
		public JniResult DestroyJavaVM() => throw new NotImplementedException();
		public JniResult DetachCurrentThread() => (JniResult)AndroidJNI.DetachCurrentThread();
		public JniResult GetEnv(out IJniEnv env, int version) {
			env = JniEnv.Instance;
			return JniResult.OK;
		}
	}
}

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

		public void AttachCurrentThread(out IJniEnv p_env, JavaVMAttachArgs? thr_args) {
			p_env = JniEnv.Instance;
			JniException.Check((JniResult)AndroidJNI.AttachCurrentThread());
		}
		public void AttachCurrentThreadAsDaemon(out IJniEnv penv, JavaVMAttachArgs? args) => throw new NotImplementedException();
		public void DestroyJavaVM() => throw new NotImplementedException();
		public void DetachCurrentThread() => JniException.Check((JniResult)AndroidJNI.DetachCurrentThread());
		public void GetEnv(out IJniEnv env, int version) => env = JniEnv.Instance;
	}
}

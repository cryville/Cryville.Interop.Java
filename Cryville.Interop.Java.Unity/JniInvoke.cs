using System;
using UnityEngine;

namespace Cryville.Interop.Java.Unity {
	/// <summary>
	/// The Unity JNI Invocation API.
	/// </summary>
	/// <remarks>
	/// <para><see cref="AttachCurrentThreadAsDaemon(JavaVMAttachArgs?)" /> and <see cref="DestroyJavaVM" /> are not implemented.</para>
	/// <para>All parameters of type <see cref="JavaVMAttachArgs" /> are not supported and ignored.</para>
	/// <para><see cref="GetEnv(int)" /> always succeeds.</para>
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

		public IJniEnv AttachCurrentThread(JavaVMAttachArgs? thr_args) {
			JniException.Check((JniResult)AndroidJNI.AttachCurrentThread());
			return JniEnv.Instance;
		}
		public IJniEnv AttachCurrentThreadAsDaemon(JavaVMAttachArgs? args) => throw new NotImplementedException();
		public void DestroyJavaVM() => throw new NotImplementedException();
		public void DetachCurrentThread() => JniException.Check((JniResult)AndroidJNI.DetachCurrentThread());
		public IJniEnv GetEnv(int version) => JniEnv.Instance;
	}
}

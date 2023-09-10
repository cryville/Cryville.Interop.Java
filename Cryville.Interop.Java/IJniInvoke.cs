namespace Cryville.Interop.Java {
	/// <summary>
	/// The JNI Invocation API.
	/// </summary>
	public interface IJniInvoke {
		/// <summary>
		/// Unloads a Java VM and reclaims its resources.
		/// </summary>
		/// <exception cref="JniException">On failure.</exception>
		/// <remarks>
		/// <para>Any thread, whether attached or not, can invoke this function. If the current thread is attached, the VM waits until the current thread is the only non-daemon user-level Java thread. If the current thread is not attached, the VM attaches the current thread and then waits until the current thread is the only non-daemon user-level thread.</para>
		/// </remarks>
		void DestroyJavaVM();
		/// <summary>
		/// Attaches the current thread to a Java VM.
		/// </summary>
		/// <param name="p_env">A JNI interface.</param>
		/// <param name="thr_args"><see langword="null" /> or a <see cref="JavaVMAttachArgs" /> structure to specify additional information.</param>
		/// <exception cref="JniException">On failure.</exception>
		/// <remarks>
		/// <para>Trying to attach a thread that is already attached is a no-op.</para>
		/// <para>A native thread cannot be attached simultaneously to two Java VMs.</para>
		/// <para>When a thread is attached to the VM, the context class loader is the bootstrap loader.</para>
		/// </remarks>
		void AttachCurrentThread(out IJniEnv p_env, JavaVMAttachArgs? thr_args);
		/// <summary>
		/// Detaches the current thread from a Java VM.
		/// </summary>
		/// <exception cref="JniException">On failure.</exception>
		/// <remarks>
		/// <para>All Java monitors held by this thread are released. All Java threads waiting for this thread to die are notified.</para>
		/// <para>The main thread can be detached from the VM.</para>
		/// </remarks>
		void DetachCurrentThread();

		/// <summary>
		/// Gets the <see cref="IJniEnv" /> attached to the current thread.
		/// </summary>
		/// <param name="env">A JNI interface, <see langword="null" /> if an error occurs.</param>
		/// <param name="version">The requested JNI version.</param>
		/// <exception cref="JniException">On failure, with a <see cref="JniException.JniResult" /> of <see cref="JniResult.Detached" /> if the current thread is not attached to the VM, or <see cref="JniResult.Version" /> if the specified version is not supported.</exception>
		void GetEnv(out IJniEnv env, int version);

		/// <summary>
		/// Same semantics as <see cref="AttachCurrentThread(out IJniEnv, JavaVMAttachArgs?)" />, but the newly-created <c>java.lang.Thread</c> instance is a daemon.
		/// </summary>
		/// <param name="penv">A JNI interface.</param>
		/// <param name="args">A <see cref="JavaVMAttachArgs" /> structure to specify additional information.</param>
		/// <exception cref="JniException">On failure.</exception>
		/// <remarks>
		/// <para>If the thread has already been attached via either <see cref="AttachCurrentThread(out IJniEnv, JavaVMAttachArgs?)" /> or <see cref="AttachCurrentThreadAsDaemon(out IJniEnv, JavaVMAttachArgs?)" />, this routine simply sets <paramref name="penv" /> to the <see cref="IJniEnv" /> of the current thread. In this case neither <see cref="AttachCurrentThread(out IJniEnv, JavaVMAttachArgs?)" /> nor this routine have any effect on the daemon status of the thread.</para>
		/// </remarks>
		void AttachCurrentThreadAsDaemon(out IJniEnv penv, JavaVMAttachArgs? args);
	}
}

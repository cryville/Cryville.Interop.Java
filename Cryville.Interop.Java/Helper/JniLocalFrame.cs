using System;

namespace Cryville.Interop.Java.Helper {
	/// <summary>
	/// Represents a local reference frame.
	/// </summary>
	/// <remarks>
	/// <para>Use this struct with a <c>using</c> statement:</para>
	/// <code>
	/// using (JniLocalFrame frame = new JniLocalFrame(env, capacity)) {
	///		// ...
	/// }
	/// </code>
	/// <para>If an object obtained within the frame is required outside the frame, use this code snippet:</para>
	/// <code>
	/// IntPtr result;
	/// using (JniLocalFrame frame = new JniLocalFrame(env, capacity)) {
	///		// ...
	///		result = frame.Pop(obj);
	/// }
	/// </code>
	/// </remarks>
	public struct JniLocalFrame : IDisposable {
		readonly IJniEnv _env;
		bool _popped;
		/// <summary>
		/// Pushes a local reference frame in which at least a given number of local references can be created.
		/// </summary>
		/// <param name="env">The <see cref="IJniEnv" />.</param>
		/// <param name="capacity">The capacity.</param>
		public JniLocalFrame(IJniEnv env, int capacity) {
			_env = env;
			_popped = false;
			env.PushLocalFrame(capacity);
		}
		/// <summary>
		/// Pops off the local reference frame, frees all the local references, and returns a local reference in the previous local reference frame for the given <paramref name="result" /> object.
		/// </summary>
		/// <param name="result">The result object.</param>
		/// <returns>A local reference in the previous local reference frame for the given <paramref name="result" /> object.</returns>
		/// <exception cref="ObjectDisposedException">The local reference frame has already been popped.</exception>
		/// <remarks>Pass <see cref="IntPtr.Zero" /> as <paramref name="result" /> if you do not need to return a reference to the previous frame.</remarks>
		public IntPtr Pop(IntPtr result) {
			if (_popped) throw new ObjectDisposedException(nameof(JniLocalFrame));
			_popped = true;
			return _env.PopLocalFrame(result);
		}
		/// <summary>
		/// Pops off the local reference frame and frees all the local references.
		/// </summary>
		public void Dispose() {
			if (_popped) return;
			_env.PopLocalFrame(IntPtr.Zero);
		}
	}
}

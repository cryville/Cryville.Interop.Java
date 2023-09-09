namespace Cryville.Interop.Java {
	/// <summary>
	/// Provides information on how the array buffer should be released.
	/// </summary>
	public enum JniReleaseArrayElementsMode {
		/// <summary>
		/// Copy back the content and free the <c>elems</c> buffer.
		/// </summary>
		Default,
		/// <summary>
		/// Copy back the content but do not free the <c>elems</c> buffer.
		/// </summary>
		Commit,
		/// <summary>
		/// Free the buffer without copying back the possible changes.
		/// </summary>
		Abort,
	}
}

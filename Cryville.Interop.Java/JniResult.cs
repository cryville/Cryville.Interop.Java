namespace Cryville.Interop.Java {
	/// <summary>
	/// Result code returned by JNI functions.
	/// </summary>
	public enum JniResult {
		/// <summary>
		/// Success.
		/// </summary>
		OK = 0,
		/// <summary>
		/// Unknown error.
		/// </summary>
		Unknown = -1,
		/// <summary>
		/// Thread detached from the VM.
		/// </summary>
		Detached = -2,
		/// <summary>
		/// JNI version error.
		/// </summary>
		Version = -3,
		/// <summary>
		/// Not enough memory.
		/// </summary>
		NoMemory = -4,
		/// <summary>
		/// VM already created.
		/// </summary>
		Existed = -5,
		/// <summary>
		/// Invalid arguments.
		/// </summary>
		Invalid = -6,
		/// <summary>
		/// Check inner exception.
		/// </summary>
		Inner = -0x1000,
	}
}

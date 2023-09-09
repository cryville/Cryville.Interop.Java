namespace Cryville.Interop.Java {
	/// <summary>
	/// Object reference type.
	/// </summary>
	public enum JniObjectRefType {
		/// <summary>
		/// Invalid reference.
		/// </summary>
		Invalid = 0,
		/// <summary>
		/// Local reference type.
		/// </summary>
		Local = 1,
		/// <summary>
		/// Global reference type.
		/// </summary>
		Global = 2,
		/// <summary>
		/// Weak global reference type.
		/// </summary>
		WeakGlobal = 3,
	}
}
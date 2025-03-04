namespace Cryville.Interop.Java.ObjectStream {
	public sealed class SerializedObjectStreamReset {
		static SerializedObjectStreamReset? s_instance;
		internal static SerializedObjectStreamReset Instance => s_instance ??= new();
		private SerializedObjectStreamReset() { }
	}
}

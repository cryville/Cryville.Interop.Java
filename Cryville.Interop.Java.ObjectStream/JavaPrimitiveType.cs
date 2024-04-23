using System.Diagnostics.CodeAnalysis;

namespace Cryville.Interop.Java.ObjectStream {
	[SuppressMessage("Design", "CA1008")]
	[SuppressMessage("Design", "CA1028")]
	[SuppressMessage("Design", "CA1720")]
	public enum JavaPrimitiveType : byte {
		Byte = 0x42,
		Char = 0x43,
		Double = 0x44,
		Float = 0x46,
		Integer = 0x49,
		Long = 0x4a,
		Short = 0x53,
		Boolean = 0x5a,
	}
}

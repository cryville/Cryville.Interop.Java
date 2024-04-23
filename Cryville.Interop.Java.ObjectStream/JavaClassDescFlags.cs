using System;
using System.Diagnostics.CodeAnalysis;

namespace Cryville.Interop.Java.ObjectStream {
	[Flags]
	[SuppressMessage("Naming", "CA1711", Justification = "[sic]")]
	[SuppressMessage("Design", "CA1028")]
	public enum JavaClassDescFlags : byte {
		WriteMethod = 0x01,
		BlockData = 0x08,
		Serializable = 0x02,
		Externalizable = 0x04,
		Enum = 0x10,
	}
}

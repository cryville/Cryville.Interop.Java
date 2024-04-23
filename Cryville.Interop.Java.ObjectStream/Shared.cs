using System.Text;

namespace Cryville.Interop.Java.ObjectStream {
	static class Shared {
		public const ushort MAGIC = 0xaced;
		public const ushort VERSION = 0x0005;
		public const byte TC_NULL = 0x70;
		public const byte TC_REFERENCE = 0x71;
		public const byte TC_CLASSDESC = 0x72;
		public const byte TC_OBJECT = 0x73;
		public const byte TC_STRING = 0x74;
		public const byte TC_ARRAY = 0x75;
		public const byte TC_CLASS = 0x76;
		public const byte TC_BLOCKDATA = 0x77;
		public const byte TC_ENDBLOCKDATA = 0x78;
		public const byte TC_RESET = 0x79;
		public const byte TC_BLOCKDATALONG = 0x7a;
		public const byte TC_EXCEPTION = 0x7b;
		public const byte TC_LONGSTRING = 0x7c;
		public const byte TC_PROXYCLASSDESC = 0x7d;
		public const byte TC_ENUM = 0x7e;
		public const int BaseWireHandle = 0x7e0000;
		public static readonly Encoding Encoding = new UTF8Encoding(false, true);
	}
}

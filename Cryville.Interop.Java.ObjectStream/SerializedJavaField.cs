using System;

namespace Cryville.Interop.Java.ObjectStream {
	public abstract class SerializedJavaField {
		public string Name { get; set; }
	}
	public class SerializedJavaPrimitiveField : SerializedJavaField {
		public JavaPrimitiveType Type { get; set; }

		public override string ToString() => $"{Type} {Name}";
	}
	public class SerializedJavaObjectField : SerializedJavaField {
		public bool IsArray { get; set; }
		public string ClassName { get; set; }

		public override string ToString() => $"{ClassName}{(IsArray ? "[]" : "")} {Name}";
	}
}

namespace Cryville.Interop.Java.ObjectStream {
	public abstract class SerializedJavaField(string name) {
		public string Name { get; set; } = name;
	}
	public class SerializedJavaPrimitiveField(string name, JavaPrimitiveType type) : SerializedJavaField(name) {
		public JavaPrimitiveType Type { get; set; } = type;

		public override string ToString() => $"{Type} {Name}";
	}
	public class SerializedJavaObjectField(string name, bool isArray, string className) : SerializedJavaField(name) {
		public bool IsArray { get; set; } = isArray;
		public string ClassName { get; set; } = className;

		public override string ToString() => $"{ClassName}{(IsArray ? "[]" : "")} {Name}";
	}
}

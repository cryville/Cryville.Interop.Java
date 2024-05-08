using System.Collections.ObjectModel;

namespace Cryville.Interop.Java.ObjectStream {
	public class SerializedJavaClassDesc(string name) : SerializedJavaContent {
		public string Name { get; set; } = name;
		public long SerialVersionUID { get; set; }
		public JavaClassDescFlags ClassDescFlags { get; set; }
		public Collection<SerializedJavaField> Fields { get; } = [];
		public Collection<object?> ClassAnnotation { get; } = [];
		public SerializedJavaClassDesc? SuperClass { get; set; }

		public override string ToString() => $"{Name} {{ Fields = [{string.Join(", ", Fields)}], ClassAnnotation = [{string.Join(", ", ClassAnnotation)}], SuperClass = {SuperClass} }}";
	}
}

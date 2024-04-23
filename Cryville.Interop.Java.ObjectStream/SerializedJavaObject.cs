using System.Collections.ObjectModel;

namespace Cryville.Interop.Java.ObjectStream {
	public class SerializedJavaObject : SerializedJavaContent {
		public SerializedJavaClassDesc? ClassDesc { get; set; }
		public Collection<object?> Values { get; } = [];
		public Collection<object?> ObjectAnnotation { get; } = [];

		public override string ToString() => $"Object {{ ClassDesc = {ClassDesc}, Values = [{string.Join(", ", Values)}], ObjectAnnotation = [{string.Join(", ", ObjectAnnotation)}] }}";
	}
}

using Cryville.Common.Compat;
using System;
using System.Collections.Generic;

namespace Cryville.Interop.Java.ObjectStream {
	public sealed class ObjectStreamContext {
		readonly Dictionary<SerializedJavaClassDesc, Dictionary<string, int>> _fieldMap = [];
		public object? GetValue(SerializedJavaObject obj, string fieldName) {
			ThrowHelper.ThrowIfNull(obj, nameof(obj));
			var classDesc = obj.ClassDesc ?? throw new ArgumentException("Missing class description.", nameof(obj));
			if (!_fieldMap.TryGetValue(classDesc, out var map)) _fieldMap.Add(classDesc, map = []);
			if (!map.TryGetValue(fieldName, out var index)) {
				for (int i = 0; i < classDesc.Fields.Count; i++) {
					if (classDesc.Fields[i].Name == fieldName) {
						map.Add(fieldName, index = i);
						goto result;
					}
				}
				throw new InvalidOperationException("Field not found.");
			}
		result:
			return obj.Values[index];
		}
		public void Reset() {
			_fieldMap.Clear();
		}
	}
}

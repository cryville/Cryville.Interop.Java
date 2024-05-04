using System;

namespace Cryville.Interop.Java.Helper {
	internal static class ArgumentHelper {
		[ThreadStatic]
		static JniValue[]? _args0;
		public static JniValue[] Args() {
			_args0 ??= [];
			return _args0;
		}
		[ThreadStatic]
		static JniValue[]? _args1;
		public static JniValue[] Args(JniValue arg0) {
			_args1 ??= new JniValue[1];
			_args1[0] = arg0;
			return _args1;
		}
	}
}

using System;

namespace Cryville.Interop.Java.Helper {
	internal static class ArgumentHelper {
		[ThreadStatic]
		static JniValue[] _args0;
		public static JniValue[] Args() {
			if (_args0 == null) _args0 = new JniValue[0];
			return _args0;
		}
		[ThreadStatic]
		static JniValue[] _args1;
		public static JniValue[] Args(JniValue arg0) {
			if (_args1 == null) _args1 = new JniValue[1];
			_args1[0] = arg0;
			return _args1;
		}
	}
}

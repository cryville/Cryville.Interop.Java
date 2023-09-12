using System;

namespace Cryville.Interop.Java.Helper {
	/// <summary>
	/// Provides a set of helper methods for Android.
	/// </summary>
	public static class AndroidHelper {
		/// <summary>
		/// Gets a local reference to the current <c>android.app.Application</c> object.
		/// </summary>
		/// <param name="env">The <see cref="IJniEnv" />.</param>
		/// <returns>A local reference to the current <c>android.app.Application</c> object.</returns>
		/// <remarks>
		/// <para>This method can only be called from the main thread, otherwise it returns a reference to <c>null</c>.</para>
		/// </remarks>
		public static IntPtr GetCurrentApplication(IJniEnv env) {
			IntPtr result = IntPtr.Zero;
			env.PushLocalFrame(2);
			try {
				var c = env.FindClass("android/app/ActivityThread");
				if (c == IntPtr.Zero) throw new InvalidOperationException("Could not find the Java class android.app.ActivityThread.");
				var m = env.GetStaticMethodID(c, "currentApplication", "Landroid/app/Application;");
				if (m == IntPtr.Zero) throw new InvalidOperationException("Could not find the method currentApplication() on Java class android.app.ActivityThread.");
				result = env.CallStaticObjectMethod(c, m, ArgumentHelper.Args());
			}
			finally {
				result = env.PopLocalFrame(result);
			}
			return result;
		}
	}
}

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
		/// <para>This method can only be called from the main thread, otherwise it may return a reference to <c>null</c>.</para>
		/// </remarks>
		public static IntPtr GetCurrentApplication(IJniEnv env) {
			using (var frame = new JniLocalFrame(env, 2)) {
				var c = env.FindClass("android/app/ActivityThread");
				if (c == IntPtr.Zero) throw new InvalidOperationException("Could not find the Java class android.app.ActivityThread.");
				var m = env.GetStaticMethodID(c, "currentApplication", "()Landroid/app/Application;");
				if (m == IntPtr.Zero) throw new InvalidOperationException("Could not find the method currentApplication() on Java class android.app.ActivityThread.");
				return frame.Pop(env.CallStaticObjectMethod(c, m, ArgumentHelper.Args()));
			}
		}

		/// <summary>
		/// Gets a local reference to a system service associated with the context specified by <paramref name="context" />.
		/// </summary>
		/// <param name="env">The <see cref="IJniEnv" />.</param>
		/// <param name="context">The context.</param>
		/// <param name="name">The name of a static field in the class <c>android.content.Context</c>.</param>
		/// <returns>A local reference to a system service.</returns>
		public static IntPtr GetSystemService(IJniEnv env, IntPtr context, string name) {
			using (var frame = new JniLocalFrame(env, 3)) {
				var c = env.FindClass("android/content/Context");
				if (c == IntPtr.Zero) throw new InvalidOperationException("Could not find the Java class android.content.Context.");
				var f = env.GetStaticFieldID(c, name, "Ljava/lang/String;");
				if (f == IntPtr.Zero) throw new InvalidOperationException(string.Format("Could not find the static field {0} on Java class android.content.Context.", name));
				var v = env.GetStaticObjectField(c, f);

				var m = env.GetMethodID(c, "getSystemService", "(Ljava/lang/String;)Ljava/lang/Object;");
				if (m == IntPtr.Zero) throw new InvalidOperationException("Could not find the method getSystemService(String) on Java class android.content.Context.");
				return frame.Pop(env.CallObjectMethod(context, m, ArgumentHelper.Args(new JniValue(v))));
			}
		}
	}
}

using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnsafeIL;

namespace Cryville.Interop.Java.Unity {
	/// <summary>
	/// The Unity Java native interface.
	/// </summary>
	/// <remarks>
	/// <para>Methods not implemented:</para>
	/// <list type="bullet">
	/// <item><see cref="CallNonvirtualObjectMethod(IntPtr, IntPtr, IntPtr, JniValue[])" /> family</item>
	/// <item><see cref="DefineClass(string, IntPtr, IntPtr, int)" /></item>
	/// <item><see cref="GetDirectBufferAddress(IntPtr)" />, <see cref="GetDirectBufferCapacity(IntPtr)" />, and <see cref="NewDirectByteBuffer(void*, long)" /></item>
	/// <item><see cref="GetObjectRefType(IntPtr)" /></item>
	/// <item><see cref="GetPrimitiveArrayCritical(IntPtr, out bool)" /> and <see cref="ReleasePrimitiveArrayCritical(IntPtr, IntPtr, JniReleaseArrayElementsMode)" /></item>
	/// <item><see cref="GetStringUTFChars(IntPtr, out bool)" />, <see cref="GetStringUTFRegion(IntPtr, int, int, byte*)" />, <see cref="NewStringUTF(byte*)" />, and <see cref="ReleaseStringUTFChars(char*, byte*)" /></item>
	/// <item><see cref="MonitorEnter(IntPtr)" /> and <see cref="MonitorExit(IntPtr)" /></item>
	/// <item><see cref="RegisterNatives(IntPtr, JniNativeMethod[])" /> and <see cref="UnregisterNatives(IntPtr)" /></item>
	/// </list>
	/// <para>Although <see cref="AndroidJNI.GetStringUTFChars(IntPtr)" /> and <see cref="AndroidJNI.NewStringUTF(string)" /> functions are exposed by Unity, they are just identical to <see cref="AndroidJNI.GetStringChars(IntPtr)" /> and <see cref="AndroidJNI.NewString(string)" />, and potentially slower. Also, they do not expose the internal <see cref="byte" /> pointer, and thus not included in this interface.</para>
	/// <para><see cref="GetStringCritical(IntPtr, out bool)" /> and <see cref="ReleaseStringCritical(IntPtr, char*)" /> are identical to <see cref="GetStringChars(IntPtr, out bool)" /> and <see cref="ReleaseStringChars(IntPtr, char*)" /> respectively.</para>
	/// </remarks>
	public unsafe class JniEnv : IJniEnv {
		static JniEnv m_instance;
		public static JniEnv Instance {
			get {
				if (m_instance == null)
					m_instance = new JniEnv();
				return m_instance;
			}
		}
		JniEnv() { }
		public IntPtr AllocObject(IntPtr clazz) => AndroidJNI.AllocObject(clazz);
		public bool CallBooleanMethod(IntPtr obj, IntPtr methodID, JniValue[] args) => AndroidJNI.CallBooleanMethod(obj, methodID, Unsafe.As<jvalue[]>(args));
		public sbyte CallByteMethod(IntPtr obj, IntPtr methodID, JniValue[] args) => AndroidJNI.CallSByteMethod(obj, methodID, Unsafe.As<jvalue[]>(args));
		public char CallCharMethod(IntPtr obj, IntPtr methodID, JniValue[] args) => AndroidJNI.CallCharMethod(obj, methodID, Unsafe.As<jvalue[]>(args));
		public double CallDoubleMethod(IntPtr obj, IntPtr methodID, JniValue[] args) => AndroidJNI.CallDoubleMethod(obj, methodID, Unsafe.As<jvalue[]>(args));
		public float CallFloatMethod(IntPtr obj, IntPtr methodID, JniValue[] args) => AndroidJNI.CallFloatMethod(obj, methodID, Unsafe.As<jvalue[]>(args));
		public int CallIntMethod(IntPtr obj, IntPtr methodID, JniValue[] args) => AndroidJNI.CallIntMethod(obj, methodID, Unsafe.As<jvalue[]>(args));
		public long CallLongMethod(IntPtr obj, IntPtr methodID, JniValue[] args) => AndroidJNI.CallLongMethod(obj, methodID, Unsafe.As<jvalue[]>(args));
		public bool CallNonvirtualBooleanMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) => throw new NotImplementedException();
		public sbyte CallNonvirtualByteMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) => throw new NotImplementedException();
		public char CallNonvirtualCharMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) => throw new NotImplementedException();
		public double CallNonvirtualDoubleMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) => throw new NotImplementedException();
		public float CallNonvirtualFloatMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) => throw new NotImplementedException();
		public int CallNonvirtualIntMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) => throw new NotImplementedException();
		public long CallNonvirtualLongMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) => throw new NotImplementedException();
		public IntPtr CallNonvirtualObjectMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) => throw new NotImplementedException();
		public short CallNonvirtualShortMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) => throw new NotImplementedException();
		public void CallNonvirtualVoidMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) => throw new NotImplementedException();
		public IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, JniValue[] args) => AndroidJNI.CallObjectMethod(obj, methodID, Unsafe.As<jvalue[]>(args));
		public short CallShortMethod(IntPtr obj, IntPtr methodID, JniValue[] args) => AndroidJNI.CallShortMethod(obj, methodID, Unsafe.As<jvalue[]>(args));
		public bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) => AndroidJNI.CallStaticBooleanMethod(clazz, methodID, Unsafe.As<jvalue[]>(args));
		public sbyte CallStaticByteMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) => AndroidJNI.CallStaticSByteMethod(clazz, methodID, Unsafe.As<jvalue[]>(args));
		public char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) => AndroidJNI.CallStaticCharMethod(clazz, methodID, Unsafe.As<jvalue[]>(args));
		public double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) => AndroidJNI.CallStaticDoubleMethod(clazz, methodID, Unsafe.As<jvalue[]>(args));
		public float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) => AndroidJNI.CallStaticFloatMethod(clazz, methodID, Unsafe.As<jvalue[]>(args));
		public int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) => AndroidJNI.CallStaticIntMethod(clazz, methodID, Unsafe.As<jvalue[]>(args));
		public long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) => AndroidJNI.CallStaticLongMethod(clazz, methodID, Unsafe.As<jvalue[]>(args));
		public IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) => AndroidJNI.CallStaticObjectMethod(clazz, methodID, Unsafe.As<jvalue[]>(args));
		public short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) => AndroidJNI.CallStaticShortMethod(clazz, methodID, Unsafe.As<jvalue[]>(args));
		public void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) => AndroidJNI.CallStaticVoidMethod(clazz, methodID, Unsafe.As<jvalue[]>(args));
		public void CallVoidMethod(IntPtr obj, IntPtr methodID, JniValue[] args) => AndroidJNI.CallVoidMethod(obj, methodID, Unsafe.As<jvalue[]>(args));
		public IntPtr DefineClass(string name, IntPtr loader, IntPtr buf, int bufLen) => throw new NotImplementedException();
		public void DeleteGlobalRef(IntPtr globalRef) => AndroidJNI.DeleteGlobalRef(globalRef);
		public void DeleteLocalRef(IntPtr localRef) => AndroidJNI.DeleteLocalRef(localRef);
		public void DeleteWeakGlobalRef(IntPtr obj) => AndroidJNI.DeleteWeakGlobalRef(obj);
		public void EnsureLocalCapacity(int capacity) => JniException.Check((JniResult)AndroidJNI.EnsureLocalCapacity(capacity));
		public bool ExceptionCheck() => AndroidJNI.ExceptionOccurred() != IntPtr.Zero;
		public void ExceptionClear() => AndroidJNI.ExceptionClear();
		public void ExceptionDescribe() => AndroidJNI.ExceptionDescribe();
		public IntPtr ExceptionOccurred() => AndroidJNI.ExceptionOccurred();
		public void FatalError(string msg) => AndroidJNI.FatalError(msg);
		public IntPtr FindClass(string name) => AndroidJNI.FindClass(name);
		public IntPtr FromReflectedField(IntPtr field) => AndroidJNI.FromReflectedField(field);
		public IntPtr FromReflectedMethod(IntPtr method) => AndroidJNI.FromReflectedMethod(method);
		public int GetArrayLength(IntPtr array) => AndroidJNI.GetArrayLength(array);
		T* GetArrayElements<T>(IntPtr array, out bool isCopy, Func<IntPtr, int, T> func) where T : unmanaged {
			int len = GetArrayLength(array);
			T* ptr = (T*)Marshal.AllocHGlobal(len * sizeof(T));
			for (int i = 0; i < len; i++) ptr[i] = func(array, i);
			isCopy = true;
			return ptr;
		}
		void GetArrayRegion<T>(IntPtr array, int start, int len, T* buf, Func<IntPtr, int, T> func) where T : unmanaged {
			if (start < 0) throw new ArgumentOutOfRangeException(nameof(start));
			int arrLen = GetArrayLength(array);
			if (start + len > arrLen) throw new ArgumentOutOfRangeException(nameof(len));
			for (int i = 0; i < len; i++) buf[i] = func(array, start + i);
		}
		readonly static Func<IntPtr, int, bool> GetBooleanArrayElement = AndroidJNI.GetBooleanArrayElement;
		public bool* GetBooleanArrayElements(IntPtr array, out bool isCopy) => GetArrayElements(array, out isCopy, GetBooleanArrayElement);
		public void GetBooleanArrayRegion(IntPtr array, int start, int len, bool* buf) => GetArrayRegion(array, start, len, buf, GetBooleanArrayElement);
		public bool GetBooleanField(IntPtr obj, IntPtr fieldID) => AndroidJNI.GetBooleanField(obj, fieldID);
		readonly static Func<IntPtr, int, sbyte> GetSByteArrayElement = AndroidJNI.GetSByteArrayElement;
		public sbyte* GetByteArrayElements(IntPtr array, out bool isCopy) => GetArrayElements(array, out isCopy, GetSByteArrayElement);
		public void GetByteArrayRegion(IntPtr array, int start, int len, sbyte* buf) => GetArrayRegion(array, start, len, buf, GetSByteArrayElement);
		public sbyte GetByteField(IntPtr obj, IntPtr fieldID) => AndroidJNI.GetSByteField(obj, fieldID);
		readonly static Func<IntPtr, int, char> GetCharArrayElement = AndroidJNI.GetCharArrayElement;
		public char* GetCharArrayElements(IntPtr array, out bool isCopy) => GetArrayElements(array, out isCopy, GetCharArrayElement);
		public void GetCharArrayRegion(IntPtr array, int start, int len, char* buf) => GetArrayRegion(array, start, len, buf, GetCharArrayElement);
		public char GetCharField(IntPtr obj, IntPtr fieldID) => AndroidJNI.GetCharField(obj, fieldID);
		public void* GetDirectBufferAddress(IntPtr buf) => throw new NotImplementedException();
		public long GetDirectBufferCapacity(IntPtr buf) => throw new NotImplementedException();
		readonly static Func<IntPtr, int, double> GetDoubleArrayElement = AndroidJNI.GetDoubleArrayElement;
		public double* GetDoubleArrayElements(IntPtr array, out bool isCopy) => GetArrayElements(array, out isCopy, GetDoubleArrayElement);
		public void GetDoubleArrayRegion(IntPtr array, int start, int len, double* buf) => GetArrayRegion(array, start, len, buf, GetDoubleArrayElement);
		public double GetDoubleField(IntPtr obj, IntPtr fieldID) => AndroidJNI.GetDoubleField(obj, fieldID);
		public IntPtr GetFieldID(IntPtr clazz, string name, string sig) => AndroidJNI.GetFieldID(clazz, name, sig);
		readonly static Func<IntPtr, int, float> GetFloatArrayElement = AndroidJNI.GetFloatArrayElement;
		public float* GetFloatArrayElements(IntPtr array, out bool isCopy) => GetArrayElements(array, out isCopy, GetFloatArrayElement);
		public void GetFloatArrayRegion(IntPtr array, int start, int len, float* buf) => GetArrayRegion(array, start, len, buf, GetFloatArrayElement);
		public float GetFloatField(IntPtr obj, IntPtr fieldID) => AndroidJNI.GetFloatField(obj, fieldID);
		readonly static Func<IntPtr, int, int> GetIntArrayElement = AndroidJNI.GetIntArrayElement;
		public int* GetIntArrayElements(IntPtr array, out bool isCopy) => GetArrayElements(array, out isCopy, GetIntArrayElement);
		public void GetIntArrayRegion(IntPtr array, int start, int len, int* buf) => GetArrayRegion(array, start, len, buf, GetIntArrayElement);
		public int GetIntField(IntPtr obj, IntPtr fieldID) => AndroidJNI.GetIntField(obj, fieldID);
		public IJniInvoke GetJavaVM() => JniInvoke.Instance;
		readonly static Func<IntPtr, int, long> GetLongArrayElement = AndroidJNI.GetLongArrayElement;
		public long* GetLongArrayElements(IntPtr array, out bool isCopy) => GetArrayElements(array, out isCopy, GetLongArrayElement);
		public void GetLongArrayRegion(IntPtr array, int start, int len, long* buf) => GetArrayRegion(array, start, len, buf, GetLongArrayElement);
		public long GetLongField(IntPtr obj, IntPtr fieldID) => AndroidJNI.GetLongField(obj, fieldID);
		public IntPtr GetMethodID(IntPtr clazz, string name, string sig) => AndroidJNI.GetMethodID(clazz, name, sig);
		public IntPtr GetObjectArrayElement(IntPtr array, int index) => AndroidJNI.GetObjectArrayElement(array, index);
		public IntPtr GetObjectClass(IntPtr obj) => AndroidJNI.GetObjectClass(obj);
		public IntPtr GetObjectField(IntPtr obj, IntPtr fieldID) => AndroidJNI.GetObjectField(obj, fieldID);
		public JniObjectRefType GetObjectRefType(IntPtr obj) => throw new NotImplementedException();
		public IntPtr GetPrimitiveArrayCritical(IntPtr array, out bool isCopy) => throw new NotImplementedException();
		readonly static Func<IntPtr, int, short> GetShortArrayElement = AndroidJNI.GetShortArrayElement;
		public short* GetShortArrayElements(IntPtr array, out bool isCopy) => GetArrayElements(array, out isCopy, GetShortArrayElement);
		public void GetShortArrayRegion(IntPtr array, int start, int len, short* buf) => GetArrayRegion(array, start, len, buf, GetShortArrayElement);
		public short GetShortField(IntPtr obj, IntPtr fieldID) => AndroidJNI.GetShortField(obj, fieldID);
		public bool GetStaticBooleanField(IntPtr clazz, IntPtr fieldID) => AndroidJNI.GetStaticBooleanField(clazz, fieldID);
		public sbyte GetStaticByteField(IntPtr clazz, IntPtr fieldID) => AndroidJNI.GetStaticSByteField(clazz, fieldID);
		public char GetStaticCharField(IntPtr clazz, IntPtr fieldID) => AndroidJNI.GetStaticCharField(clazz, fieldID);
		public double GetStaticDoubleField(IntPtr clazz, IntPtr fieldID) => AndroidJNI.GetStaticDoubleField(clazz, fieldID);
		public IntPtr GetStaticFieldID(IntPtr clazz, string name, string sig) => AndroidJNI.GetStaticFieldID(clazz, name, sig);
		public float GetStaticFloatField(IntPtr clazz, IntPtr fieldID) => AndroidJNI.GetStaticFloatField(clazz, fieldID);
		public int GetStaticIntField(IntPtr clazz, IntPtr fieldID) => AndroidJNI.GetStaticIntField(clazz, fieldID);
		public long GetStaticLongField(IntPtr clazz, IntPtr fieldID) => AndroidJNI.GetStaticLongField(clazz, fieldID);
		public IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig) => AndroidJNI.GetStaticMethodID(clazz, name, sig);
		public IntPtr GetStaticObjectField(IntPtr clazz, IntPtr fieldID) => AndroidJNI.GetStaticObjectField(clazz, fieldID);
		public short GetStaticShortField(IntPtr clazz, IntPtr fieldID) => AndroidJNI.GetStaticShortField(clazz, fieldID);
		public char* GetStringChars(IntPtr str, out bool isCopy) {
			var s = AndroidJNI.GetStringChars(str);
			char* ptr = (char*)Marshal.AllocHGlobal(s.Length * sizeof(char));
			for (int i = 0; i < s.Length; i++) ptr[i] = s[i];
			isCopy = true;
			return ptr;
		}
		public char* GetStringCritical(IntPtr str, out bool isCopy) => GetStringChars(str, out isCopy);
		public int GetStringLength(IntPtr str) => AndroidJNI.GetStringLength(str);
		public void GetStringRegion(IntPtr str, int start, int len, char* buf) {
			if (start < 0) throw new ArgumentOutOfRangeException(nameof(start));
			int strLen = GetStringLength(str);
			if (start + len > strLen) throw new ArgumentOutOfRangeException(nameof(len));
			var s = AndroidJNI.GetStringChars(str);
			for (int i = 0; i < len; i++) buf[i] = s[start + i];
		}
		public byte* GetStringUTFChars(IntPtr str, out bool isCopy) => throw new NotImplementedException();
		public int GetStringUTFLength(IntPtr str) => AndroidJNI.GetStringUTFLength(str);
		public void GetStringUTFRegion(IntPtr str, int start, int len, byte* buf) => throw new NotImplementedException();
		public IntPtr GetSuperclass(IntPtr clazz) => AndroidJNI.GetSuperclass(clazz);
		public int GetVersion() => AndroidJNI.GetVersion();
		public bool IsAssignableFrom(IntPtr clazz1, IntPtr clazz2) => AndroidJNI.IsAssignableFrom(clazz1, clazz2);
		public bool IsInstanceOf(IntPtr obj, IntPtr clazz) => AndroidJNI.IsInstanceOf(obj, clazz);
		public bool IsSameObject(IntPtr ref1, IntPtr ref2) => AndroidJNI.IsSameObject(ref1, ref2);
		public void MonitorEnter(IntPtr obj) => throw new NotImplementedException();
		public void MonitorExit(IntPtr obj) => throw new NotImplementedException();
		public IntPtr NewBooleanArray(int length) => AndroidJNI.NewBooleanArray(length);
		public IntPtr NewByteArray(int length) => AndroidJNI.NewSByteArray(length);
		public IntPtr NewCharArray(int length) => AndroidJNI.NewCharArray(length);
		public IntPtr NewDirectByteBuffer(void* address, long capacity) => throw new NotImplementedException();
		public IntPtr NewDoubleArray(int length) => AndroidJNI.NewDoubleArray(length);
		public IntPtr NewFloatArray(int length) => AndroidJNI.NewFloatArray(length);
		public IntPtr NewGlobalRef(IntPtr obj) => AndroidJNI.NewGlobalRef(obj);
		public IntPtr NewIntArray(int length) => AndroidJNI.NewIntArray(length);
		public IntPtr NewLocalRef(IntPtr reference) => AndroidJNI.NewLocalRef(reference);
		public IntPtr NewLongArray(int length) => AndroidJNI.NewLongArray(length);
		public IntPtr NewObject(IntPtr clazz, IntPtr methodID, JniValue[] args) => AndroidJNI.NewObject(clazz, methodID, Unsafe.As<jvalue[]>(args));
		public IntPtr NewObjectArray(int length, IntPtr elementClass, IntPtr initialElement) => AndroidJNI.NewObjectArray(length, elementClass, initialElement);
		public IntPtr NewShortArray(int length) => AndroidJNI.NewShortArray(length);
		public IntPtr NewString(char* unicodeChars, int len) => AndroidJNI.NewString(new string(unicodeChars, 0, len));
		public IntPtr NewStringUTF(byte* bytes) => throw new NotImplementedException();
		public IntPtr NewWeakGlobalRef(IntPtr obj) => AndroidJNI.NewWeakGlobalRef(obj);
		public IntPtr PopLocalFrame(IntPtr result) => AndroidJNI.PopLocalFrame(result);
		public void PushLocalFrame(int capacity) => JniException.Check((JniResult)AndroidJNI.PushLocalFrame(capacity));
		public void RegisterNatives(IntPtr clazz, JniNativeMethod[] methods) => throw new NotImplementedException();
		public void ReleaseBooleanArrayElements(IntPtr array, bool* elems, JniReleaseArrayElementsMode mode) => Marshal.FreeHGlobal((IntPtr)elems);
		public void ReleaseByteArrayElements(IntPtr array, sbyte* elems, JniReleaseArrayElementsMode mode) => Marshal.FreeHGlobal((IntPtr)elems);
		public void ReleaseCharArrayElements(IntPtr array, char* elems, JniReleaseArrayElementsMode mode) => Marshal.FreeHGlobal((IntPtr)elems);
		public void ReleaseDoubleArrayElements(IntPtr array, double* elems, JniReleaseArrayElementsMode mode) => Marshal.FreeHGlobal((IntPtr)elems);
		public void ReleaseFloatArrayElements(IntPtr array, float* elems, JniReleaseArrayElementsMode mode) => Marshal.FreeHGlobal((IntPtr)elems);
		public void ReleaseIntArrayElements(IntPtr array, int* elems, JniReleaseArrayElementsMode mode) => Marshal.FreeHGlobal((IntPtr)elems);
		public void ReleaseLongArrayElements(IntPtr array, long* elems, JniReleaseArrayElementsMode mode) => Marshal.FreeHGlobal((IntPtr)elems);
		public void ReleasePrimitiveArrayCritical(IntPtr array, IntPtr carray, JniReleaseArrayElementsMode mode) => throw new NotImplementedException();
		public void ReleaseShortArrayElements(IntPtr array, short* elems, JniReleaseArrayElementsMode mode) => Marshal.FreeHGlobal((IntPtr)elems);
		public void ReleaseStringChars(IntPtr str, char* chars) => Marshal.FreeHGlobal((IntPtr)chars);
		public void ReleaseStringCritical(IntPtr str, char* carray) => Marshal.FreeHGlobal((IntPtr)carray);
		public void ReleaseStringUTFChars(char* str, byte* utf) => throw new NotImplementedException();
		void SetArrayRegion<T>(IntPtr array, int start, int len, T* buf, Action<IntPtr, int, T> func) where T : unmanaged {
			if (start < 0) throw new ArgumentOutOfRangeException(nameof(start));
			int arrLen = GetArrayLength(array);
			if (start + len > arrLen) throw new ArgumentOutOfRangeException(nameof(len));
			for (int i = 0; i < len; i++) func(array, start + i, buf[i]);
		}
		static readonly Action<IntPtr, int, bool> SetBooleanArrayElement = AndroidJNI.SetBooleanArrayElement;
		public void SetBooleanArrayRegion(IntPtr array, int start, int len, bool* buf) => SetArrayRegion(array, start, len, buf, SetBooleanArrayElement);
		public void SetBooleanField(IntPtr obj, IntPtr fieldID, bool value) => AndroidJNI.SetBooleanField(obj, fieldID, value);
		static readonly Action<IntPtr, int, sbyte> SetSByteArrayElement = AndroidJNI.SetSByteArrayElement;
		public void SetByteArrayRegion(IntPtr array, int start, int len, sbyte* buf) => SetArrayRegion(array, start, len, buf, SetSByteArrayElement);
		public void SetByteField(IntPtr obj, IntPtr fieldID, sbyte value) => AndroidJNI.SetSByteField(obj, fieldID, value);
		static readonly Action<IntPtr, int, char> SetCharArrayElement = AndroidJNI.SetCharArrayElement;
		public void SetCharArrayRegion(IntPtr array, int start, int len, char* buf) => SetArrayRegion(array, start, len, buf, SetCharArrayElement);
		public void SetCharField(IntPtr obj, IntPtr fieldID, char value) => AndroidJNI.SetCharField(obj, fieldID, value);
		static readonly Action<IntPtr, int, double> SetDoubleArrayElement = AndroidJNI.SetDoubleArrayElement;
		public void SetDoubleArrayRegion(IntPtr array, int start, int len, double* buf) => SetArrayRegion(array, start, len, buf, SetDoubleArrayElement);
		public void SetDoubleField(IntPtr obj, IntPtr fieldID, double value) => AndroidJNI.SetDoubleField(obj, fieldID, value);
		static readonly Action<IntPtr, int, float> SetFloatArrayElement = AndroidJNI.SetFloatArrayElement;
		public void SetFloatArrayRegion(IntPtr array, int start, int len, float* buf) => SetArrayRegion(array, start, len, buf, SetFloatArrayElement);
		public void SetFloatField(IntPtr obj, IntPtr fieldID, float value) => AndroidJNI.SetFloatField(obj, fieldID, value);
		static readonly Action<IntPtr, int, int> SetIntArrayElement = AndroidJNI.SetIntArrayElement;
		public void SetIntArrayRegion(IntPtr array, int start, int len, int* buf) => SetArrayRegion(array, start, len, buf, SetIntArrayElement);
		public void SetIntField(IntPtr obj, IntPtr fieldID, int value) => AndroidJNI.SetIntField(obj, fieldID, value);
		static readonly Action<IntPtr, int, long> SetLongArrayElement = AndroidJNI.SetLongArrayElement;
		public void SetLongArrayRegion(IntPtr array, int start, int len, long* buf) => SetArrayRegion(array, start, len, buf, SetLongArrayElement);
		public void SetLongField(IntPtr obj, IntPtr fieldID, long value) => AndroidJNI.SetLongField(obj, fieldID, value);
		public void SetObjectArrayElement(IntPtr array, int index, IntPtr value) => AndroidJNI.SetObjectArrayElement(array, index, value);
		public void SetObjectField(IntPtr obj, IntPtr fieldID, IntPtr value) => AndroidJNI.SetObjectField(obj, fieldID, value);
		static readonly Action<IntPtr, int, short> SetShortArrayElement = AndroidJNI.SetShortArrayElement;
		public void SetShortArrayRegion(IntPtr array, int start, int len, short* buf) => SetArrayRegion(array, start, len, buf, SetShortArrayElement);
		public void SetShortField(IntPtr obj, IntPtr fieldID, short value) => AndroidJNI.SetShortField(obj, fieldID, value);
		public void SetStaticBooleanField(IntPtr clazz, IntPtr fieldID, bool value) => AndroidJNI.SetStaticBooleanField(clazz, fieldID, value);
		public void SetStaticByteField(IntPtr clazz, IntPtr fieldID, sbyte value) => AndroidJNI.SetStaticSByteField(clazz, fieldID, value);
		public void SetStaticCharField(IntPtr clazz, IntPtr fieldID, char value) => AndroidJNI.SetStaticCharField(clazz, fieldID, value);
		public void SetStaticDoubleField(IntPtr clazz, IntPtr fieldID, double value) => AndroidJNI.SetStaticDoubleField(clazz, fieldID, value);
		public void SetStaticFloatField(IntPtr clazz, IntPtr fieldID, float value) => AndroidJNI.SetStaticFloatField(clazz, fieldID, value);
		public void SetStaticIntField(IntPtr clazz, IntPtr fieldID, int value) => AndroidJNI.SetStaticIntField(clazz, fieldID, value);
		public void SetStaticLongField(IntPtr clazz, IntPtr fieldID, long value) => AndroidJNI.SetStaticLongField(clazz, fieldID, value);
		public void SetStaticObjectField(IntPtr clazz, IntPtr fieldID, IntPtr value) => AndroidJNI.SetStaticObjectField(clazz, fieldID, value);
		public void SetStaticShortField(IntPtr clazz, IntPtr fieldID, short value) => AndroidJNI.SetStaticShortField(clazz, fieldID, value);
		public void ThrowObject(IntPtr obj) => JniException.Check((JniResult)AndroidJNI.Throw(obj));
		public void ThrowNew(IntPtr clazz, string message) => JniException.Check((JniResult)AndroidJNI.ThrowNew(clazz, message));
		public IntPtr ToReflectedField(IntPtr cls, IntPtr fieldID, bool isStatic) => AndroidJNI.ToReflectedField(cls, fieldID, isStatic);
		public IntPtr ToReflectedMethod(IntPtr cls, IntPtr methodID, bool isStatic) => AndroidJNI.ToReflectedMethod(cls, methodID, isStatic);
		public void UnregisterNatives(IntPtr clazz) => throw new NotImplementedException();
	}
}

using Java.Interop;
using System;
using System.Collections.Generic;
using UnsafeIL;
using static Java.Interop.JniEnvironment;
using Arrays = Java.Interop.JniEnvironment.Arrays;
using Object = Java.Interop.JniEnvironment.Object;
using ReleaseMode = Java.Interop.JniReleaseArrayElementsMode;

namespace Cryville.Interop.Java.Xamarin {
	/// <summary>
	/// The Xamarin Java native interface.
	/// </summary>
	/// <remarks>
	/// <para>Methods not implemented:</para>
	/// <list type="bullet">
	/// <item><see cref="FromReflectedField(IntPtr)" />, <see cref="FromReflectedMethod(IntPtr)" />, <see cref="ToReflectedField(IntPtr, IntPtr, bool)" />, and <see cref="ToReflectedMethod(IntPtr, IntPtr, bool)" /></item>
	/// <item><see cref="GetObjectRefType(IntPtr)" /></item>
	/// <item><see cref="GetStringUTFChars(IntPtr, out bool)" />, <see cref="GetStringUTFLength(IntPtr)" />, <see cref="GetStringUTFRegion(IntPtr, int, int, byte*)" />, <see cref="NewStringUTF(byte*)" />, and <see cref="ReleaseStringUTFChars(char*, byte*)" /></item>
	/// </list>
	/// <para><see cref="GetStringCritical(IntPtr, out bool)" /> and <see cref="ReleaseStringCritical(IntPtr, char*)" /> are identical to <see cref="GetStringChars(IntPtr, out bool)" /> and <see cref="ReleaseStringChars(IntPtr, char*)" /> respectively.</para>
	/// </remarks>
	public unsafe class JniEnv : IJniEnv {
		static JniEnv m_instance;
		/// <summary>
		/// An instance of the <see cref="JniEnv" /> singleton class.
		/// </summary>
		public static JniEnv Instance => m_instance ??= new JniEnv();
		JniEnv() { }

		/// <inheritdoc />
		public IntPtr AllocObject(IntPtr clazz) => Object.AllocObject(new JniObjectReference(clazz)).Handle;
		readonly Dictionary<IntPtr, JniMethodInfo> _methods = new Dictionary<IntPtr, JniMethodInfo>();
		JniMethodInfo GetMethod(IntPtr methodID) {
			if (!_methods.TryGetValue(methodID, out var methodInfo))
				_methods.Add(methodID, methodInfo = new JniMethodInfo(methodID, false));
			return methodInfo;
		}
		/// <inheritdoc />
		public bool CallBooleanMethod(IntPtr obj, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallBooleanMethod(new JniObjectReference(obj), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public sbyte CallByteMethod(IntPtr obj, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallByteMethod(new JniObjectReference(obj), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public char CallCharMethod(IntPtr obj, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallCharMethod(new JniObjectReference(obj), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public double CallDoubleMethod(IntPtr obj, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallDoubleMethod(new JniObjectReference(obj), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public float CallFloatMethod(IntPtr obj, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallFloatMethod(new JniObjectReference(obj), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public int CallIntMethod(IntPtr obj, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallIntMethod(new JniObjectReference(obj), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public long CallLongMethod(IntPtr obj, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallLongMethod(new JniObjectReference(obj), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public bool CallNonvirtualBooleanMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallNonvirtualBooleanMethod(new JniObjectReference(obj), new JniObjectReference(clazz), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public sbyte CallNonvirtualByteMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallNonvirtualByteMethod(new JniObjectReference(obj), new JniObjectReference(clazz), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public char CallNonvirtualCharMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallNonvirtualCharMethod(new JniObjectReference(obj), new JniObjectReference(clazz), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public double CallNonvirtualDoubleMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallNonvirtualDoubleMethod(new JniObjectReference(obj), new JniObjectReference(clazz), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public float CallNonvirtualFloatMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallNonvirtualFloatMethod(new JniObjectReference(obj), new JniObjectReference(clazz), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public int CallNonvirtualIntMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallNonvirtualIntMethod(new JniObjectReference(obj), new JniObjectReference(clazz), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public long CallNonvirtualLongMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallNonvirtualLongMethod(new JniObjectReference(obj), new JniObjectReference(clazz), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public IntPtr CallNonvirtualObjectMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallNonvirtualObjectMethod(new JniObjectReference(obj), new JniObjectReference(clazz), GetMethod(methodID), (JniArgumentValue*)pargs).Handle;
		}
		/// <inheritdoc />
		public short CallNonvirtualShortMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallNonvirtualShortMethod(new JniObjectReference(obj), new JniObjectReference(clazz), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public void CallNonvirtualVoidMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) InstanceMethods.CallNonvirtualVoidMethod(new JniObjectReference(obj), new JniObjectReference(clazz), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallObjectMethod(new JniObjectReference(obj), GetMethod(methodID), (JniArgumentValue*)pargs).Handle;
		}
		/// <inheritdoc />
		public short CallShortMethod(IntPtr obj, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return InstanceMethods.CallShortMethod(new JniObjectReference(obj), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		readonly Dictionary<IntPtr, JniMethodInfo> _staticMethods = new Dictionary<IntPtr, JniMethodInfo>();
		JniMethodInfo GetStaticMethod(IntPtr methodID) {
			if (!_staticMethods.TryGetValue(methodID, out var methodInfo))
				_staticMethods.Add(methodID, methodInfo = new JniMethodInfo(methodID, true));
			return methodInfo;
		}
		/// <inheritdoc />
		public bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return StaticMethods.CallStaticBooleanMethod(new JniObjectReference(clazz), GetStaticMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public sbyte CallStaticByteMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return StaticMethods.CallStaticByteMethod(new JniObjectReference(clazz), GetStaticMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return StaticMethods.CallStaticCharMethod(new JniObjectReference(clazz), GetStaticMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return StaticMethods.CallStaticDoubleMethod(new JniObjectReference(clazz), GetStaticMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return StaticMethods.CallStaticFloatMethod(new JniObjectReference(clazz), GetStaticMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return StaticMethods.CallStaticIntMethod(new JniObjectReference(clazz), GetStaticMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return StaticMethods.CallStaticLongMethod(new JniObjectReference(clazz), GetStaticMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return StaticMethods.CallStaticObjectMethod(new JniObjectReference(clazz), GetStaticMethod(methodID), (JniArgumentValue*)pargs).Handle;
		}
		/// <inheritdoc />
		public short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return StaticMethods.CallStaticShortMethod(new JniObjectReference(clazz), GetStaticMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) StaticMethods.CallStaticVoidMethod(new JniObjectReference(clazz), GetStaticMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public void CallVoidMethod(IntPtr obj, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) InstanceMethods.CallVoidMethod(new JniObjectReference(obj), GetMethod(methodID), (JniArgumentValue*)pargs);
		}
		/// <inheritdoc />
		public IntPtr DefineClass(string name, IntPtr loader, IntPtr buf, int bufLen) => Types.DefineClass(name, new JniObjectReference(loader), buf, bufLen).Handle;
		/// <inheritdoc />
		public void DeleteGlobalRef(IntPtr globalRef) {
			var r = new JniObjectReference(globalRef, JniObjectReferenceType.Global);
			JniObjectReference.Dispose(ref r);
		}
		/// <inheritdoc />
		public void DeleteLocalRef(IntPtr localRef) {
			var r = new JniObjectReference(localRef, JniObjectReferenceType.Local);
			JniObjectReference.Dispose(ref r);
		}
		/// <inheritdoc />
		public void DeleteWeakGlobalRef(IntPtr obj) {
			var r = new JniObjectReference(obj, JniObjectReferenceType.WeakGlobal);
			JniObjectReference.Dispose(ref r);
		}
		/// <inheritdoc />
		public void EnsureLocalCapacity(int capacity) {
			try { References.EnsureLocalCapacity(capacity); }
			catch (JavaException ex) { throw new JniException(ex); }
			catch (InvalidOperationException ex) { throw new JniException(ex); }
		}
		/// <inheritdoc />
		public bool ExceptionCheck() => Exceptions.ExceptionCheck();
		/// <inheritdoc />
		public void ExceptionClear() => Exceptions.ExceptionClear();
		/// <inheritdoc />
		public void ExceptionDescribe() => Exceptions.ExceptionDescribe();
		/// <inheritdoc />
		public IntPtr ExceptionOccurred() => Exceptions.ExceptionOccurred().Handle;
		/// <inheritdoc />
		public void FatalError(string msg) => Exceptions.FatalError(msg);
		/// <inheritdoc />
		public IntPtr FindClass(string name) => Types.FindClass(name).Handle;
		/// <inheritdoc />
		public IntPtr FromReflectedField(IntPtr field) => throw new NotImplementedException();
		/// <inheritdoc />
		public IntPtr FromReflectedMethod(IntPtr method) => throw new NotImplementedException();
		/// <inheritdoc />
		public int GetArrayLength(IntPtr array) => Arrays.GetArrayLength(new JniObjectReference(array));
		/// <inheritdoc />
		public unsafe bool* GetBooleanArrayElements(IntPtr array, out bool isCopy) {
			fixed (bool* ptr = &isCopy) return Arrays.GetBooleanArrayElements(new JniObjectReference(array), ptr);
		}
		/// <inheritdoc />
		public unsafe void GetBooleanArrayRegion(IntPtr array, int start, int len, bool* buf) => Arrays.GetBooleanArrayRegion(new JniObjectReference(array), start, len, buf);
		readonly Dictionary<IntPtr, JniFieldInfo> _fields = new Dictionary<IntPtr, JniFieldInfo>();
		JniFieldInfo GetField(IntPtr fieldID) {
			if (!_fields.TryGetValue(fieldID, out var fieldInfo))
				_fields.Add(fieldID, fieldInfo = new JniFieldInfo(fieldID, false));
			return fieldInfo;
		}
		/// <inheritdoc />
		public bool GetBooleanField(IntPtr obj, IntPtr fieldID) => InstanceFields.GetBooleanField(new JniObjectReference(obj), GetField(fieldID));
		/// <inheritdoc />
		public unsafe sbyte* GetByteArrayElements(IntPtr array, out bool isCopy) {
			fixed (bool* ptr = &isCopy) return Arrays.GetByteArrayElements(new JniObjectReference(array), ptr);
		}
		/// <inheritdoc />
		public unsafe void GetByteArrayRegion(IntPtr array, int start, int len, sbyte* buf) => Arrays.GetByteArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public sbyte GetByteField(IntPtr obj, IntPtr fieldID) => InstanceFields.GetByteField(new JniObjectReference(obj), GetField(fieldID));
		/// <inheritdoc />
		public unsafe char* GetCharArrayElements(IntPtr array, out bool isCopy) {
			fixed (bool* ptr = &isCopy) return Arrays.GetCharArrayElements(new JniObjectReference(array), ptr);
		}
		/// <inheritdoc />
		public unsafe void GetCharArrayRegion(IntPtr array, int start, int len, char* buf) => Arrays.GetCharArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public char GetCharField(IntPtr obj, IntPtr fieldID) => InstanceFields.GetCharField(new JniObjectReference(obj), GetField(fieldID));
		/// <inheritdoc />
		public unsafe void* GetDirectBufferAddress(IntPtr buf) => IO.GetDirectBufferAddress(new JniObjectReference(buf)).ToPointer();
		/// <inheritdoc />
		public long GetDirectBufferCapacity(IntPtr buf) => IO.GetDirectBufferCapacity(new JniObjectReference(buf));
		/// <inheritdoc />
		public unsafe double* GetDoubleArrayElements(IntPtr array, out bool isCopy) {
			fixed (bool* ptr = &isCopy) return Arrays.GetDoubleArrayElements(new JniObjectReference(array), ptr);
		}
		/// <inheritdoc />
		public unsafe void GetDoubleArrayRegion(IntPtr array, int start, int len, double* buf) => Arrays.GetDoubleArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public double GetDoubleField(IntPtr obj, IntPtr fieldID) => InstanceFields.GetDoubleField(new JniObjectReference(obj), GetField(fieldID));
		/// <inheritdoc />
		public IntPtr GetFieldID(IntPtr clazz, string name, string sig) => InstanceFields.GetFieldID(new JniObjectReference(clazz), name, sig).ID;
		/// <inheritdoc />
		public unsafe float* GetFloatArrayElements(IntPtr array, out bool isCopy) {
			fixed (bool* ptr = &isCopy) return Arrays.GetFloatArrayElements(new JniObjectReference(array), ptr);
		}
		/// <inheritdoc />
		public unsafe void GetFloatArrayRegion(IntPtr array, int start, int len, float* buf) => Arrays.GetFloatArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public float GetFloatField(IntPtr obj, IntPtr fieldID) => InstanceFields.GetFloatField(new JniObjectReference(obj), GetField(fieldID));
		/// <inheritdoc />
		public unsafe int* GetIntArrayElements(IntPtr array, out bool isCopy) {
			fixed (bool* ptr = &isCopy) return Arrays.GetIntArrayElements(new JniObjectReference(array), ptr);
		}
		/// <inheritdoc />
		public unsafe void GetIntArrayRegion(IntPtr array, int start, int len, int* buf) => Arrays.GetIntArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public int GetIntField(IntPtr obj, IntPtr fieldID) => InstanceFields.GetIntField(new JniObjectReference(obj), GetField(fieldID));
		/// <inheritdoc />
		public IJniInvoke GetJavaVM() => JniInvoke.Instance;
		/// <inheritdoc />
		public unsafe long* GetLongArrayElements(IntPtr array, out bool isCopy) {
			fixed (bool* ptr = &isCopy) return Arrays.GetLongArrayElements(new JniObjectReference(array), ptr);
		}
		/// <inheritdoc />
		public unsafe void GetLongArrayRegion(IntPtr array, int start, int len, long* buf) => Arrays.GetLongArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public long GetLongField(IntPtr obj, IntPtr fieldID) => InstanceFields.GetLongField(new JniObjectReference(obj), GetField(fieldID));
		/// <inheritdoc />
		public IntPtr GetMethodID(IntPtr clazz, string name, string sig) => InstanceMethods.GetMethodID(new JniObjectReference(clazz), name, sig).ID;
		/// <inheritdoc />
		public IntPtr GetObjectArrayElement(IntPtr array, int index) => Arrays.GetObjectArrayElement(new JniObjectReference(array), index).Handle;
		/// <inheritdoc />
		public IntPtr GetObjectClass(IntPtr obj) => Types.GetObjectClass(new JniObjectReference(obj)).Handle;
		/// <inheritdoc />
		public IntPtr GetObjectField(IntPtr obj, IntPtr fieldID) => InstanceFields.GetObjectField(new JniObjectReference(obj), GetField(fieldID)).Handle;
		/// <inheritdoc />
		public JniObjectRefType GetObjectRefType(IntPtr obj) => throw new NotImplementedException();
		/// <inheritdoc />
		public IntPtr GetPrimitiveArrayCritical(IntPtr array, out bool isCopy) {
			fixed (bool* ptr = &isCopy) return Arrays.GetPrimitiveArrayCritical(new JniObjectReference(array), ptr);
		}
		/// <inheritdoc />
		public unsafe short* GetShortArrayElements(IntPtr array, out bool isCopy) {
			fixed (bool* ptr = &isCopy) return Arrays.GetShortArrayElements(new JniObjectReference(array), ptr);
		}
		/// <inheritdoc />
		public unsafe void GetShortArrayRegion(IntPtr array, int start, int len, short* buf) => Arrays.GetShortArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public short GetShortField(IntPtr obj, IntPtr fieldID) => InstanceFields.GetShortField(new JniObjectReference(obj), GetField(fieldID));
		readonly Dictionary<IntPtr, JniFieldInfo> _staticFields = new Dictionary<IntPtr, JniFieldInfo>();
		JniFieldInfo GetStaticField(IntPtr fieldID) {
			if (!_staticFields.TryGetValue(fieldID, out var fieldInfo))
				_staticFields.Add(fieldID, fieldInfo = new JniFieldInfo(fieldID, true));
			return fieldInfo;
		}
		/// <inheritdoc />
		public bool GetStaticBooleanField(IntPtr clazz, IntPtr fieldID) => StaticFields.GetStaticBooleanField(new JniObjectReference(clazz), GetStaticField(fieldID));
		/// <inheritdoc />
		public sbyte GetStaticByteField(IntPtr clazz, IntPtr fieldID) => StaticFields.GetStaticByteField(new JniObjectReference(clazz), GetStaticField(fieldID));
		/// <inheritdoc />
		public char GetStaticCharField(IntPtr clazz, IntPtr fieldID) => StaticFields.GetStaticCharField(new JniObjectReference(clazz), GetStaticField(fieldID));
		/// <inheritdoc />
		public double GetStaticDoubleField(IntPtr clazz, IntPtr fieldID) => StaticFields.GetStaticDoubleField(new JniObjectReference(clazz), GetStaticField(fieldID));
		/// <inheritdoc />
		public IntPtr GetStaticFieldID(IntPtr clazz, string name, string sig) => StaticFields.GetStaticFieldID(new JniObjectReference(clazz), name, sig).ID;
		/// <inheritdoc />
		public float GetStaticFloatField(IntPtr clazz, IntPtr fieldID) => StaticFields.GetStaticFloatField(new JniObjectReference(clazz), GetStaticField(fieldID));
		/// <inheritdoc />
		public int GetStaticIntField(IntPtr clazz, IntPtr fieldID) => StaticFields.GetStaticIntField(new JniObjectReference(clazz), GetStaticField(fieldID));
		/// <inheritdoc />
		public long GetStaticLongField(IntPtr clazz, IntPtr fieldID) => StaticFields.GetStaticLongField(new JniObjectReference(clazz), GetStaticField(fieldID));
		/// <inheritdoc />
		public IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig) => StaticMethods.GetStaticMethodID(new JniObjectReference(clazz), name, sig).ID;
		/// <inheritdoc />
		public IntPtr GetStaticObjectField(IntPtr clazz, IntPtr fieldID) => StaticFields.GetStaticObjectField(new JniObjectReference(clazz), GetStaticField(fieldID)).Handle;
		/// <inheritdoc />
		public short GetStaticShortField(IntPtr clazz, IntPtr fieldID) => StaticFields.GetStaticShortField(new JniObjectReference(clazz), GetStaticField(fieldID));
		/// <inheritdoc />
		public unsafe char* GetStringChars(IntPtr @string, out bool isCopy) {
			fixed (bool* ptr = &isCopy) return Strings.GetStringChars(new JniObjectReference(@string), ptr);
		}
		/// <inheritdoc />
		public unsafe char* GetStringCritical(IntPtr @string, out bool isCopy) => GetStringChars(@string, out isCopy);
		/// <inheritdoc />
		public int GetStringLength(IntPtr @string) => Strings.GetStringLength(new JniObjectReference(@string));
		/// <inheritdoc />
		public unsafe void GetStringRegion(IntPtr str, int start, int len, char* buf) {
			if (start < 0) throw new ArgumentOutOfRangeException(nameof(start));
			int strLen = GetStringLength(str);
			if (start + len > strLen) throw new ArgumentOutOfRangeException(nameof(len));
			bool _;
			var s = GetStringChars(str, out _);
			Unsafe.CopyBlock(buf, s + start, (uint)len * sizeof(char));
			ReleaseStringChars(str, s);
		}
		/// <inheritdoc />
		public unsafe byte* GetStringUTFChars(IntPtr @string, out bool isCopy) => throw new NotImplementedException();
		/// <inheritdoc />
		public int GetStringUTFLength(IntPtr @string) => throw new NotImplementedException();
		/// <inheritdoc />
		public unsafe void GetStringUTFRegion(IntPtr str, int start, int len, byte* buf) => throw new NotImplementedException();
		/// <inheritdoc />
		public IntPtr GetSuperclass(IntPtr clazz) => Types.GetSuperclass(new JniObjectReference(clazz)).Handle;
		/// <inheritdoc />
		public int GetVersion() => (int)JniEnvironment.JniVersion;
		/// <inheritdoc />
		public bool IsAssignableFrom(IntPtr clazz1, IntPtr clazz2) => Types.IsAssignableFrom(new JniObjectReference(clazz1), new JniObjectReference(clazz2));
		/// <inheritdoc />
		public bool IsInstanceOf(IntPtr obj, IntPtr clazz) => Types.IsInstanceOf(new JniObjectReference(obj), new JniObjectReference(clazz));
		/// <inheritdoc />
		public bool IsSameObject(IntPtr ref1, IntPtr ref2) => Types.IsSameObject(new JniObjectReference(ref1), new JniObjectReference(ref2));
		/// <inheritdoc />
		public void MonitorEnter(IntPtr obj) {
			try { Monitors.MonitorEnter(new JniObjectReference(obj)); }
			catch (JavaException ex) { throw new JniException(ex); }
			catch (InvalidOperationException ex) { throw new JniException(ex); }
		}
		/// <inheritdoc />
		public void MonitorExit(IntPtr obj) {
			try { Monitors.MonitorExit(new JniObjectReference(obj)); }
			catch (JavaException ex) { throw new JniException(ex); }
			catch (InvalidOperationException ex) { throw new JniException(ex); }
		}
		/// <inheritdoc />
		public IntPtr NewBooleanArray(int length) => Arrays.NewBooleanArray(length).Handle;
		/// <inheritdoc />
		public IntPtr NewByteArray(int length) => Arrays.NewByteArray(length).Handle;
		/// <inheritdoc />
		public IntPtr NewCharArray(int length) => Arrays.NewCharArray(length).Handle;
		/// <inheritdoc />
		public unsafe IntPtr NewDirectByteBuffer(void* address, long capacity) => IO.NewDirectByteBuffer((IntPtr)address, capacity).Handle;
		/// <inheritdoc />
		public IntPtr NewDoubleArray(int length) => Arrays.NewDoubleArray(length).Handle;
		/// <inheritdoc />
		public IntPtr NewFloatArray(int length) => Arrays.NewFloatArray(length).Handle;
		/// <inheritdoc />
		public IntPtr NewGlobalRef(IntPtr obj) => new JniObjectReference(obj).NewGlobalRef().Handle;
		/// <inheritdoc />
		public IntPtr NewIntArray(int length) => Arrays.NewIntArray(length).Handle;
		/// <inheritdoc />
		public IntPtr NewLocalRef(IntPtr @ref) => new JniObjectReference(@ref).NewLocalRef().Handle;
		/// <inheritdoc />
		public IntPtr NewLongArray(int length) => Arrays.NewLongArray(length).Handle;
		/// <inheritdoc />
		public IntPtr NewObject(IntPtr clazz, IntPtr methodID, JniValue[] args) {
			fixed (JniValue* pargs = args) return Object.NewObject(new JniObjectReference(clazz), GetMethod(methodID), (JniArgumentValue*)pargs).Handle;
		}
		/// <inheritdoc />
		public IntPtr NewObjectArray(int length, IntPtr elementClass, IntPtr initialElement) => Arrays.NewObjectArray(length, new JniObjectReference(elementClass), new JniObjectReference(initialElement)).Handle;
		/// <inheritdoc />
		public IntPtr NewShortArray(int length) => Arrays.NewShortArray(length).Handle;
		/// <inheritdoc />
		public unsafe IntPtr NewString(char* unicodeChars, int len) => Strings.NewString(unicodeChars, len).Handle;
		/// <inheritdoc />
		public unsafe IntPtr NewStringUTF(byte* bytes) => throw new NotImplementedException();
		/// <inheritdoc />
		public IntPtr NewWeakGlobalRef(IntPtr obj) => new JniObjectReference(obj).NewWeakGlobalRef().Handle;
		/// <inheritdoc />
		public IntPtr PopLocalFrame(IntPtr result) => References.PopLocalFrame(new JniObjectReference(result)).Handle;
		/// <inheritdoc />
		public void PushLocalFrame(int capacity) {
			try { References.PushLocalFrame(capacity); }
			catch (JavaException ex) { throw new JniException(ex); }
			catch (InvalidOperationException ex) { throw new JniException(ex); }
		}
		/// <inheritdoc />
		public void RegisterNatives(IntPtr clazz, JniNativeMethod[] methods) {
			try { Types.RegisterNatives(new JniObjectReference(clazz), Unsafe.As<JniNativeMethodRegistration[]>(methods)); }
			catch (JavaException ex) { throw new JniException(ex); }
			catch (InvalidOperationException ex) { throw new JniException(ex); }
		}
		/// <inheritdoc />
		public unsafe void ReleaseBooleanArrayElements(IntPtr array, bool* elems, JniReleaseArrayElementsMode mode) => Arrays.ReleaseBooleanArrayElements(new JniObjectReference(array), elems, (ReleaseMode)(int)mode);
		/// <inheritdoc />
		public unsafe void ReleaseByteArrayElements(IntPtr array, sbyte* elems, JniReleaseArrayElementsMode mode) => Arrays.ReleaseByteArrayElements(new JniObjectReference(array), elems, (ReleaseMode)(int)mode);
		/// <inheritdoc />
		public unsafe void ReleaseCharArrayElements(IntPtr array, char* elems, JniReleaseArrayElementsMode mode) => Arrays.ReleaseCharArrayElements(new JniObjectReference(array), elems, (ReleaseMode)(int)mode);
		/// <inheritdoc />
		public unsafe void ReleaseDoubleArrayElements(IntPtr array, double* elems, JniReleaseArrayElementsMode mode) => Arrays.ReleaseDoubleArrayElements(new JniObjectReference(array), elems, (ReleaseMode)(int)mode);
		/// <inheritdoc />
		public unsafe void ReleaseFloatArrayElements(IntPtr array, float* elems, JniReleaseArrayElementsMode mode) => Arrays.ReleaseFloatArrayElements(new JniObjectReference(array), elems, (ReleaseMode)(int)mode);
		/// <inheritdoc />
		public unsafe void ReleaseIntArrayElements(IntPtr array, int* elems, JniReleaseArrayElementsMode mode) => Arrays.ReleaseIntArrayElements(new JniObjectReference(array), elems, (ReleaseMode)(int)mode);
		/// <inheritdoc />
		public unsafe void ReleaseLongArrayElements(IntPtr array, long* elems, JniReleaseArrayElementsMode mode) => Arrays.ReleaseLongArrayElements(new JniObjectReference(array), elems, (ReleaseMode)(int)mode);
		/// <inheritdoc />
		public void ReleasePrimitiveArrayCritical(IntPtr array, IntPtr carray, JniReleaseArrayElementsMode mode) => Arrays.ReleasePrimitiveArrayCritical(new JniObjectReference(array), carray, (ReleaseMode)(int)mode);
		/// <inheritdoc />
		public unsafe void ReleaseShortArrayElements(IntPtr array, short* elems, JniReleaseArrayElementsMode mode) => Arrays.ReleaseShortArrayElements(new JniObjectReference(array), elems, (ReleaseMode)(int)mode);
		/// <inheritdoc />
		public unsafe void ReleaseStringChars(IntPtr @string, char* chars) => Strings.ReleaseStringChars(new JniObjectReference(@string), chars);
		/// <inheritdoc />
		public unsafe void ReleaseStringCritical(IntPtr @string, char* carray) => ReleaseStringChars(@string, carray);
		/// <inheritdoc />
		public unsafe void ReleaseStringUTFChars(char* @string, byte* utf) => throw new NotImplementedException();
		/// <inheritdoc />
		public unsafe void SetBooleanArrayRegion(IntPtr array, int start, int len, bool* buf) => Arrays.SetBooleanArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public void SetBooleanField(IntPtr obj, IntPtr fieldID, bool value) => InstanceFields.SetBooleanField(new JniObjectReference(obj), GetField(fieldID), value);
		/// <inheritdoc />
		public unsafe void SetByteArrayRegion(IntPtr array, int start, int len, sbyte* buf) => Arrays.SetByteArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public void SetByteField(IntPtr obj, IntPtr fieldID, sbyte value) => InstanceFields.SetByteField(new JniObjectReference(obj), GetField(fieldID), value);
		/// <inheritdoc />
		public unsafe void SetCharArrayRegion(IntPtr array, int start, int len, char* buf) => Arrays.SetCharArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public void SetCharField(IntPtr obj, IntPtr fieldID, char value) => InstanceFields.SetCharField(new JniObjectReference(obj), GetField(fieldID), value);
		/// <inheritdoc />
		public unsafe void SetDoubleArrayRegion(IntPtr array, int start, int len, double* buf) => Arrays.SetDoubleArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public void SetDoubleField(IntPtr obj, IntPtr fieldID, double value) => InstanceFields.SetDoubleField(new JniObjectReference(obj), GetField(fieldID), value);
		/// <inheritdoc />
		public unsafe void SetFloatArrayRegion(IntPtr array, int start, int len, float* buf) => Arrays.SetFloatArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public void SetFloatField(IntPtr obj, IntPtr fieldID, float value) => InstanceFields.SetFloatField(new JniObjectReference(obj), GetField(fieldID), value);
		/// <inheritdoc />
		public unsafe void SetIntArrayRegion(IntPtr array, int start, int len, int* buf) => Arrays.SetIntArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public void SetIntField(IntPtr obj, IntPtr fieldID, int value) => InstanceFields.SetIntField(new JniObjectReference(obj), GetField(fieldID), value);
		/// <inheritdoc />
		public unsafe void SetLongArrayRegion(IntPtr array, int start, int len, long* buf) => Arrays.SetLongArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public void SetLongField(IntPtr obj, IntPtr fieldID, long value) => InstanceFields.SetLongField(new JniObjectReference(obj), GetField(fieldID), value);
		/// <inheritdoc />
		public void SetObjectArrayElement(IntPtr array, int index, IntPtr value) => Arrays.SetObjectArrayElement(new JniObjectReference(array), index, new JniObjectReference(value));
		/// <inheritdoc />
		public void SetObjectField(IntPtr obj, IntPtr fieldID, IntPtr value) => InstanceFields.SetObjectField(new JniObjectReference(obj), GetField(fieldID), new JniObjectReference(value));
		/// <inheritdoc />
		public unsafe void SetShortArrayRegion(IntPtr array, int start, int len, short* buf) => Arrays.SetShortArrayRegion(new JniObjectReference(array), start, len, buf);
		/// <inheritdoc />
		public void SetShortField(IntPtr obj, IntPtr fieldID, short value) => InstanceFields.SetShortField(new JniObjectReference(obj), GetField(fieldID), value);
		/// <inheritdoc />
		public void SetStaticBooleanField(IntPtr clazz, IntPtr fieldID, bool value) => StaticFields.SetStaticBooleanField(new JniObjectReference(clazz), GetStaticField(fieldID), value);
		/// <inheritdoc />
		public void SetStaticByteField(IntPtr clazz, IntPtr fieldID, sbyte value) => StaticFields.SetStaticByteField(new JniObjectReference(clazz), GetStaticField(fieldID), value);
		/// <inheritdoc />
		public void SetStaticCharField(IntPtr clazz, IntPtr fieldID, char value) => StaticFields.SetStaticCharField(new JniObjectReference(clazz), GetStaticField(fieldID), value);
		/// <inheritdoc />
		public void SetStaticDoubleField(IntPtr clazz, IntPtr fieldID, double value) => StaticFields.SetStaticDoubleField(new JniObjectReference(clazz), GetStaticField(fieldID), value);
		/// <inheritdoc />
		public void SetStaticFloatField(IntPtr clazz, IntPtr fieldID, float value) => StaticFields.SetStaticFloatField(new JniObjectReference(clazz), GetStaticField(fieldID), value);
		/// <inheritdoc />
		public void SetStaticIntField(IntPtr clazz, IntPtr fieldID, int value) => StaticFields.SetStaticIntField(new JniObjectReference(clazz), GetStaticField(fieldID), value);
		/// <inheritdoc />
		public void SetStaticLongField(IntPtr clazz, IntPtr fieldID, long value) => StaticFields.SetStaticLongField(new JniObjectReference(clazz), GetStaticField(fieldID), value);
		/// <inheritdoc />
		public void SetStaticObjectField(IntPtr clazz, IntPtr fieldID, IntPtr value) => StaticFields.SetStaticObjectField(new JniObjectReference(clazz), GetStaticField(fieldID), new JniObjectReference(value));
		/// <inheritdoc />
		public void SetStaticShortField(IntPtr clazz, IntPtr fieldID, short value) => StaticFields.SetStaticShortField(new JniObjectReference(clazz), GetStaticField(fieldID), value);
		/// <inheritdoc />
		public void ThrowObject(IntPtr obj) {
			try { Exceptions.Throw(new JniObjectReference(obj)); }
			catch (JavaException ex) { throw new JniException(ex); }
			catch (InvalidOperationException ex) { throw new JniException(ex); }
		}
		/// <inheritdoc />
		public void ThrowNew(IntPtr clazz, string message) {
			try { Exceptions.ThrowNew(new JniObjectReference(clazz), message); }
			catch (JavaException ex) { throw new JniException(ex); }
			catch (InvalidOperationException ex) { throw new JniException(ex); }
		}
		/// <inheritdoc />
		public IntPtr ToReflectedField(IntPtr cls, IntPtr fieldID, bool isStatic) => throw new NotImplementedException();
		/// <inheritdoc />
		public IntPtr ToReflectedMethod(IntPtr cls, IntPtr methodID, bool isStatic) => throw new NotImplementedException();
		/// <inheritdoc />
		public void UnregisterNatives(IntPtr clazz) {
			try { Types.UnregisterNatives(new JniObjectReference(clazz)); }
			catch (JavaException ex) { throw new JniException(ex); }
			catch (InvalidOperationException ex) { throw new JniException(ex); }
		}
	}
}

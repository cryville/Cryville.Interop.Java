using System;

namespace Cryville.Interop.Java {
	/// <summary>
	/// The Java native interface.
	/// </summary>
	public unsafe interface IJniEnv {
		/// <summary>
		/// Returns the version of the native method interface.
		/// </summary>
		/// <returns>The version of the native method interface.</returns>
		/// <remarks>
		/// <para>Returns the major version number in the higher 16 bits and the minor version number in the lower 16 bits.</para>
		/// <para>In JDK/JRE 1.1, <see cref="GetVersion" /> returns <c>0x00010001</c>.</para>
		/// <para>In JDK/JRE 1.2, <see cref="GetVersion" /> returns <c>0x00010002</c>.</para>
		/// <para>In JDK/JRE 1.4, <see cref="GetVersion" /> returns <c>0x00010004</c>.</para>
		/// <para>In JDK/JRE 1.6, <see cref="GetVersion" /> returns <c>0x00010006</c>.</para>
		/// </remarks>
		int GetVersion();

		/// <summary>
		/// Loads a class from a buffer of raw class data.
		/// </summary>
		/// <param name="name">The name of the class or interface to be defined.</param>
		/// <param name="loader">A class loader assigned to the defined class.</param>
		/// <param name="buf">Buffer containing the .class file data.</param>
		/// <param name="bufLen">Buffer length.</param>
		/// <returns>A Java class object or <see cref="IntPtr.Zero" /> if an error occurs.</returns>
		/// <remarks>
		/// <para>The buffer containing the raw class data is not referenced by the VM after the DefineClass call returns, and it may be discarded if desired.</para>
		/// </remarks>
		IntPtr DefineClass(string name, IntPtr loader, IntPtr buf, int bufLen);
		/// <summary>
		/// Searches and loads a defined class.
		/// </summary>
		/// <param name="name">A fully-qualified class name (that is, a package name, delimited by “/”, followed by the class name). If the name begins with “[“ (the array signature character), it returns an array class.</param>
		/// <returns>A class object from a fully-qualified name, or <see cref="IntPtr.Zero" /> if the class cannot be found.</returns>
		/// <remarks>
		/// <para>In JDK release 1.1, this function loads a locally-defined class. It searches the directories and zip files specified by the <c>CLASSPATH</c> environment variable for the class with the specified name.</para>
		/// <para>Since Java 2 SDK release 1.2, the Java security model allows non-system classes to load and call native methods. <see cref="FindClass(string)" /> locates the class loader associated with the current native method; that is, the class loader of the class that declared the native method. If the native method belongs to a system class, no class loader will be involved. Otherwise, the proper class loader will be invoked to load and link the named class.</para>
		/// <para>Since Java 2 SDK release 1.2, when <see cref="FindClass(string)" /> is called through the Invocation Interface, there is no current native method or its associated class loader. In that case, the result of <c>ClassLoader.getSystemClassLoader</c> is used. This is the class loader the virtual machine creates for applications, and is able to locate classes listed in the <c>java.class.path</c> property.</para>
		/// <para>The name argument is a fully-qualified class name or an array type signature. For example, the fully-qualified class name for the <c>java.lang.String</c> class is:</para>
		/// <code>"java/lang/String"</code>
		/// <para>The array type signature of the array class <c>java.lang.Object[]</c> is:</para>
		/// <code>"[Ljava/lang/Object;"</code>
		/// </remarks>
		IntPtr FindClass(string name);

		/// <summary>
		/// Converts a <c>java.lang.reflect.Method</c> or <c>java.lang.reflect.Constructor</c> object to a method ID.
		/// </summary>
		/// <param name="method">A <c>java.lang.reflect.Method</c> or <c>java.lang.reflect.Constructor</c> object.</param>
		/// <returns>A method ID.</returns>
		IntPtr FromReflectedMethod(IntPtr method);
		/// <summary>
		/// Converts a <c>java.lang.reflect.Field</c> to a field ID.
		/// </summary>
		/// <param name="field">A <c>java.lang.reflect.Field</c>.</param>
		/// <returns>A field ID.</returns>
		IntPtr FromReflectedField(IntPtr field);
		/// <summary>
		/// Converts a method ID derived from <paramref name="cls" /> to a <c>java.lang.reflect.Method</c> or <c>java.lang.reflect.Constructor</c> object.
		/// </summary>
		/// <param name="cls">A Java class.</param>
		/// <param name="methodID">A method ID.</param>
		/// <param name="isStatic">Whether the method ID refers to a static field.</param>
		/// <returns>A <c>java.lang.reflect.Method</c> or <c>java.lang.reflect.Constructor</c> object. <see cref="IntPtr.Zero" /> if fails.</returns>
		IntPtr ToReflectedMethod(IntPtr cls, IntPtr methodID, bool isStatic);

		/// <summary>
		/// Returns the object that represents the superclass of the class specified by <paramref name="clazz" />.
		/// </summary>
		/// <param name="clazz">A Java class object.</param>
		/// <returns>The superclass of the class represented by <paramref name="clazz" />, or <see cref="IntPtr.Zero" />.</returns>
		/// <remarks>
		/// <para>If <paramref name="clazz" /> represents any class other than the class <c>Object</c>, then this function returns the object that represents the superclass of the class specified by <paramref name="clazz" />.</para>
		/// <para>If <paramref name="clazz" /> specifies the class <c>Object</c>, or <paramref name="clazz" /> represents an interface, this function returns <see cref="IntPtr.Zero" />.</para>
		/// </remarks>
		IntPtr GetSuperclass(IntPtr clazz);

		/// <summary>
		/// Determines whether an object of <paramref name="clazz1" /> can be safely cast to <paramref name="clazz2" />.
		/// </summary>
		/// <param name="clazz1">The first class argument.</param>
		/// <param name="clazz2">The second class argument.</param>
		/// <returns><see langword="true" /> if either of the following is true:<list type="bullet"><item>The first and second class arguments refer to the same Java class.</item><item>The first class is a subclass of the second class.</item><item>The first class has the second class as one of its interfaces.</item></list></returns>
		bool IsAssignableFrom(IntPtr clazz1, IntPtr clazz2);

		/// <summary>
		/// Converts a field ID derived from <paramref name="cls" /> to a <c>java.lang.reflect.Field</c> object.
		/// </summary>
		/// <param name="cls">A Java class.</param>
		/// <param name="fieldID">A field ID.</param>
		/// <param name="isStatic">Whether <paramref name="fieldID" /> refers to a static field.</param>
		/// <returns>A <c>java.lang.reflect.Field</c> object. <see cref="IntPtr.Zero" /> if fails.</returns>
		IntPtr ToReflectedField(IntPtr cls, IntPtr fieldID, bool isStatic);
		/// <summary>
		/// Causes a <c>java.lang.Throwable</c> object to be thrown.
		/// </summary>
		/// <param name="obj">A <c>java.lang.Throwable</c> object.</param>
		/// <exception cref="JniException">On failure.</exception>
		void Throw(IntPtr obj);
		/// <summary>
		/// Constructs an exception object from the specified class with the message specified by <paramref name="message" /> and causes that exception to be thrown.
		/// </summary>
		/// <param name="clazz">A subclass of <c>java.lang.Throwable</c>.</param>
		/// <param name="message">The message used to construct the <c>java.lang.Throwable</c> object.</param>
		/// <exception cref="JniException">On failure.</exception>
		void ThrowNew(IntPtr clazz, string message);
		/// <summary>
		/// Determines if an exception is being thrown.
		/// </summary>
		/// <returns>The exception object that is currently in the process of being thrown, or <see cref="IntPtr.Zero" /> if no exception is currently being thrown.</returns>
		/// <remarks>
		/// <para>The exception stays being thrown until either the native code calls <see cref="ExceptionClear" />, or the Java code handles the exception.</para>
		/// </remarks>
		IntPtr ExceptionOccurred();
		/// <summary>
		/// Prints an exception and a backtrace of the stack to a system error-reporting channel, such as <c>stderr</c>.
		/// </summary>
		/// <remarks>
		/// <para>This is a convenience routine provided for debugging.</para>
		/// </remarks>
		void ExceptionDescribe();
		/// <summary>
		/// Clears any exception that is currently being thrown.
		/// </summary>
		/// <remarks>
		/// <para>If no exception is currently being thrown, this routine has no effect.</para>
		/// </remarks>
		void ExceptionClear();
		/// <summary>
		/// Raises a fatal error and does not expect the VM to recover. This function does not return.
		/// </summary>
		/// <param name="msg">An error message.</param>
		void FatalError(string msg);

		/// <summary>
		/// Creates a new local reference frame, in which at least a given number of local references can be created.
		/// </summary>
		/// <param name="capacity"></param>
		/// <exception cref="JniException">On failure with a pending <c>OutOfMemoryError</c>.</exception>
		/// <remarks>
		/// <para>Note that local references already created in previous local frames are still valid in the current local frame.</para>
		/// </remarks>
		void PushLocalFrame(int capacity);
		/// <summary>
		/// Pops off the current local reference frame, frees all the local references, and returns a local reference in the previous local reference frame for the given <paramref name="result" /> object.
		/// </summary>
		/// <param name="result">The result object.</param>
		/// <returns>A local reference in the previous local reference frame for the given <paramref name="result" /> object.</returns>
		/// <remarks>
		/// <para>Pass <see cref="IntPtr.Zero" /> as <paramref name="result" /> if you do not need to return a reference to the previous frame.</para>
		/// </remarks>
		IntPtr PopLocalFrame(IntPtr result);

		/// <summary>
		/// Creates a new global reference to the object referred to by the <paramref name="obj" /> argument.
		/// </summary>
		/// <param name="obj">A global or local reference.</param>
		/// <returns>A global reference to the given <paramref name="obj" />. <see cref="IntPtr.Zero" /> if:<list type="bullet"><item><paramref name="obj" /> refers to <c>null</c></item><item>the system has run out of memory</item><item><paramref name="obj" /> was a weak global reference and has already been garbage collected</item></list></returns>
		/// <remarks>
		/// <para>Global references must be explicitly disposed of by calling <see cref="DeleteGlobalRef(IntPtr)" />.</para>
		/// </remarks>
		IntPtr NewGlobalRef(IntPtr obj);
		/// <summary>
		/// Deletes the global reference pointed to by <paramref name="globalRef" />.
		/// </summary>
		/// <param name="globalRef">A global reference.</param>
		void DeleteGlobalRef(IntPtr globalRef);
		/// <summary>
		/// Deletes the local reference pointed to by <paramref name="localRef" />.
		/// </summary>
		/// <param name="localRef">A local reference.</param>
		/// <remarks>
		/// <para>JDK/JRE 1.1 provides the <see cref="DeleteLocalRef(IntPtr)" /> function so that programmers can manually delete local references. For example, if native code iterates through a potentially large array of objects and uses one element in each iteration, it is a good practice to delete the local reference to the no-longer-used array element before a new local reference is created in the next iteration.</para>
		/// <para>As of JDK/JRE 1.2 an additional set of functions are provided for local reference lifetime management. They are the four functions listed below:</para>
		/// <list type="bullet">
		/// <item><see cref="EnsureLocalCapacity(int)" /></item>
		/// <item><see cref="PushLocalFrame(int)" /></item>
		/// <item><see cref="PopLocalFrame(IntPtr)" /></item>
		/// <item><see cref="NewLocalRef(IntPtr)" /></item>
		/// </list>
		/// </remarks>
		void DeleteLocalRef(IntPtr localRef);
		/// <summary>
		/// Tests whether two references refer to the same Java object.
		/// </summary>
		/// <param name="ref1">A Java object.</param>
		/// <param name="ref2">A Java object.</param>
		/// <returns><see langword="true" /> if <paramref name="ref1" /> and <paramref name="ref2" /> refer to the same Java object, or are both <c>null</c>; otherwise, <see langword="false" />.</returns>
		bool IsSameObject(IntPtr ref1, IntPtr ref2);

		/// <summary>
		/// Creates a new local reference that refers to the same object as <paramref name="ref" />.
		/// </summary>
		/// <param name="ref">A global or local reference.</param>
		/// <returns>A new local reference that refers to the same object as <paramref name="ref" />. <see cref="IntPtr.Zero" /> if <paramref name="ref" /> refers to <c>null</c>.</returns>
		IntPtr NewLocalRef(IntPtr @ref);
		/// <summary>
		/// Ensures that at least a given number of local references can be created in the current thread.
		/// </summary>
		/// <param name="capacity">The number of local references.</param>
		/// <exception cref="JniException">On failure with a pending <c>OutOfMemoryError</c>.</exception>
		/// <remarks>
		/// <para>Before it enters a native method, the VM automatically ensures that at least 16 local references can be created.</para>
		/// <para>For backward compatibility, the VM allocates local references beyond the ensured capacity. (As a debugging support, the VM may give the user warnings that too many local references are being created. In the JDK, the programmer can supply the <c>-verbose:jni</c> command line option to turn on these messages.) The VM calls <c>FatalError</c> if no more local references can be created beyond the ensured capacity.</para>
		/// </remarks>
		void EnsureLocalCapacity(int capacity);

		/// <summary>
		/// Allocates a new Java object without invoking any of the constructors for the object.
		/// </summary>
		/// <param name="clazz">A Java class object.</param>
		/// <returns>A Java object, or <see cref="IntPtr.Zero" /> if the object cannot be constructed.</returns>
		/// <remarks>
		/// <para>The <paramref name="clazz" /> argument must not refer to an array class.</para>
		/// </remarks>
		IntPtr AllocObject(IntPtr clazz);
		/// <summary>
		/// Constructs a new Java object.
		/// </summary>
		/// <param name="clazz">A Java class object.</param>
		/// <param name="methodID">The method ID of the constructor.</param>
		/// <param name="args">An array of arguments to the constructor.</param>
		/// <returns>A Java object, or <see cref="IntPtr.Zero" /> if the object cannot be constructed.</returns>
		/// <remarks>
		/// <para>The method ID indicates which constructor method to invoke. This ID must be obtained by calling <see cref="GetMethodID(IntPtr, string, string)" /> with <c>&lt;init&gt;</c> as the method name and <c>void</c> (<c>V</c>) as the return type.</para>
		/// <para>The <paramref name="clazz" /> argument must not refer to an array class.</para>
		/// </remarks>
		IntPtr NewObject(IntPtr clazz, IntPtr methodID, JniValue[] args);

		/// <summary>
		/// Returns the class of an object.
		/// </summary>
		/// <param name="obj">A Java object (must not be <see cref="IntPtr.Zero" />).</param>
		/// <returns>A Java class object.</returns>
		IntPtr GetObjectClass(IntPtr obj);
		/// <summary>
		/// Tests whether an object is an instance of a class.
		/// </summary>
		/// <param name="obj">A Java object.</param>
		/// <param name="clazz">A Java class object.</param>
		/// <returns><see langword="true" /> if <paramref name="obj" /> can be cast to <paramref name="clazz" />; otherwise, <see langword="false" />.</returns>
		/// <remarks>
		/// <para><c>null</c> can be cast to any class.</para>
		/// </remarks>
		bool IsInstanceOf(IntPtr obj, IntPtr clazz);
		/// <summary>
		/// Returns the method ID for an instance (nonstatic) method of a class or interface.
		/// </summary>
		/// <param name="clazz">A Java class object.</param>
		/// <param name="name">The method name.</param>
		/// <param name="sig">The method signature.</param>
		/// <returns>A method ID, or <see cref="IntPtr.Zero" /> if the specified method cannot be found.</returns>
		/// <remarks>
		/// <para>The method may be defined in one of the <paramref name="clazz" />’s superclasses and inherited by <paramref name="clazz" />. The method is determined by its name and signature.</para>
		/// <para><see cref="GetMethodID(IntPtr, string, string)" /> causes an uninitialized class to be initialized.</para>
		/// <para>To obtain the method ID of a constructor, supply <c>&lt;init&gt;</c> as the method name and <c>void</c> (<c>V</c>) as the return type.</para>
		/// </remarks>
		IntPtr GetMethodID(IntPtr clazz, string name, string sig);

		/// <summary>
		/// Invokes an instance (nonstatic) method on a Java object, according to the specified method ID.
		/// </summary>
		/// <param name="obj">A Java object.</param>
		/// <param name="methodID">A method ID.</param>
		/// <param name="args">An array of arguments.</param>
		/// <returns>The result of calling the Java method.</returns>
		/// <remarks>
		/// <para>The <paramref name="methodID" /> argument must be obtained by calling <see cref="GetMethodID(IntPtr, string, string)" />.</para>
		/// <para>When the function is used to call private methods and constructors, the method ID must be derived from the real class of <paramref name="obj" />, not from one of its superclasses.</para>
		/// </remarks>
		IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallObjectMethod(IntPtr, IntPtr, JniValue[])" />
		bool CallBooleanMethod(IntPtr obj, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallObjectMethod(IntPtr, IntPtr, JniValue[])" />
		sbyte CallByteMethod(IntPtr obj, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallObjectMethod(IntPtr, IntPtr, JniValue[])" />
		char CallCharMethod(IntPtr obj, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallObjectMethod(IntPtr, IntPtr, JniValue[])" />
		short CallShortMethod(IntPtr obj, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallObjectMethod(IntPtr, IntPtr, JniValue[])" />
		int CallIntMethod(IntPtr obj, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallObjectMethod(IntPtr, IntPtr, JniValue[])" />
		long CallLongMethod(IntPtr obj, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallObjectMethod(IntPtr, IntPtr, JniValue[])" />
		float CallFloatMethod(IntPtr obj, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallObjectMethod(IntPtr, IntPtr, JniValue[])" />
		double CallDoubleMethod(IntPtr obj, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallObjectMethod(IntPtr, IntPtr, JniValue[])" />
		void CallVoidMethod(IntPtr obj, IntPtr methodID, JniValue[] args);

		/// <summary>
		/// Invokes an instance (nonstatic) method on a Java object, based on the class, designated by the <paramref name="clazz" /> parameter, from which the method ID is obtained.
		/// </summary>
		/// <param name="obj">A Java object.</param>
		/// <param name="clazz">A Java class.</param>
		/// <param name="methodID">A method ID.</param>
		/// <param name="args">An array of arguments.</param>
		/// <returns>The result of calling the Java method.</returns>
		/// <remarks>
		/// <para>The <paramref name="methodID" /> argument must be obtained by calling <see cref="GetMethodID(IntPtr, string, string)" />.</para>
		/// <para>The <see cref="CallNonvirtualObjectMethod(IntPtr, IntPtr, IntPtr, JniValue[])" /> families of routines and the <see cref="CallObjectMethod(IntPtr, IntPtr, JniValue[])" /> families of routines are different. <see cref="CallObjectMethod(IntPtr, IntPtr, JniValue[])" /> routines invoke the method based on the class of the object, while <see cref="CallNonvirtualObjectMethod(IntPtr, IntPtr, IntPtr, JniValue[])" /> routines invoke the method based on the class, designated by the <paramref name="clazz" /> parameter, from which the method ID is obtained. The method ID must be obtained from the real class of the object or from one of its superclasses.</para>
		/// </remarks>
		IntPtr CallNonvirtualObjectMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallNonvirtualObjectMethod(IntPtr, IntPtr, IntPtr, JniValue[])" />
		bool CallNonvirtualBooleanMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallNonvirtualObjectMethod(IntPtr, IntPtr, IntPtr, JniValue[])" />
		sbyte CallNonvirtualByteMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallNonvirtualObjectMethod(IntPtr, IntPtr, IntPtr, JniValue[])" />
		char CallNonvirtualCharMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallNonvirtualObjectMethod(IntPtr, IntPtr, IntPtr, JniValue[])" />
		short CallNonvirtualShortMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallNonvirtualObjectMethod(IntPtr, IntPtr, IntPtr, JniValue[])" />
		int CallNonvirtualIntMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallNonvirtualObjectMethod(IntPtr, IntPtr, IntPtr, JniValue[])" />
		long CallNonvirtualLongMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallNonvirtualObjectMethod(IntPtr, IntPtr, IntPtr, JniValue[])" />
		float CallNonvirtualFloatMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallNonvirtualObjectMethod(IntPtr, IntPtr, IntPtr, JniValue[])" />
		double CallNonvirtualDoubleMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallNonvirtualObjectMethod(IntPtr, IntPtr, IntPtr, JniValue[])" />
		void CallNonvirtualVoidMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, JniValue[] args);

		/// <summary>
		/// Returns the field ID for an instance (nonstatic) field of a class.
		/// </summary>
		/// <param name="clazz">A Java class object.</param>
		/// <param name="name">The field name.</param>
		/// <param name="sig">The field signature.</param>
		/// <returns>A field ID, or <see cref="IntPtr.Zero" /> if the operation fails.</returns>
		/// <remarks>
		/// <para>The field is specified by its name and signature. The <see cref="GetObjectField(IntPtr, IntPtr)" /> and <see cref="SetObjectField(IntPtr, IntPtr, IntPtr)" /> families of accessor functions use field IDs to retrieve object fields.</para>
		/// <para><see cref="GetFieldID(IntPtr, string, string)" /> causes an uninitialized class to be initialized.</para>
		/// <para><see cref="GetFieldID(IntPtr, string, string)" /> cannot be used to obtain the length field of an array. Use <see cref="GetArrayLength(IntPtr)" /> instead.</para>
		/// </remarks>
		IntPtr GetFieldID(IntPtr clazz, string name, string sig);

		/// <summary>
		/// Returns the value of an instance (nonstatic) field of an object.
		/// </summary>
		/// <param name="obj">A Java object (must not be <see cref="IntPtr.Zero" />).</param>
		/// <param name="fieldID">A valid field ID.</param>
		/// <returns>The content of the field.</returns>
		/// <remarks>
		/// <para>The field to access is specified by a field ID obtained by calling <see cref="GetFieldID(IntPtr, string, string)" />.</para>
		/// </remarks>
		IntPtr GetObjectField(IntPtr obj, IntPtr fieldID);
		/// <inheritdoc cref="GetObjectField(IntPtr, IntPtr)" />
		bool GetBooleanField(IntPtr obj, IntPtr fieldID);
		/// <inheritdoc cref="GetObjectField(IntPtr, IntPtr)" />
		sbyte GetByteField(IntPtr obj, IntPtr fieldID);
		/// <inheritdoc cref="GetObjectField(IntPtr, IntPtr)" />
		char GetCharField(IntPtr obj, IntPtr fieldID);
		/// <inheritdoc cref="GetObjectField(IntPtr, IntPtr)" />
		short GetShortField(IntPtr obj, IntPtr fieldID);
		/// <inheritdoc cref="GetObjectField(IntPtr, IntPtr)" />
		int GetIntField(IntPtr obj, IntPtr fieldID);
		/// <inheritdoc cref="GetObjectField(IntPtr, IntPtr)" />
		long GetLongField(IntPtr obj, IntPtr fieldID);
		/// <inheritdoc cref="GetObjectField(IntPtr, IntPtr)" />
		float GetFloatField(IntPtr obj, IntPtr fieldID);
		/// <inheritdoc cref="GetObjectField(IntPtr, IntPtr)" />
		double GetDoubleField(IntPtr obj, IntPtr fieldID);

		/// <summary>
		/// Sets the value of an instance (nonstatic) field of an object.
		/// </summary>
		/// <param name="obj">A Java object (must not be <see cref="IntPtr.Zero" />).</param>
		/// <param name="fieldID">A valid field ID.</param>
		/// <param name="value">The new value of the field.</param>
		/// <remarks>
		/// <para>The field to access is specified by a field ID obtained by calling <see cref="GetFieldID(IntPtr, string, string)" />.</para>
		/// </remarks>
		void SetObjectField(IntPtr obj, IntPtr fieldID, IntPtr value);
		/// <inheritdoc cref="SetObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetBooleanField(IntPtr obj, IntPtr fieldID, bool value);
		/// <inheritdoc cref="SetObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetByteField(IntPtr obj, IntPtr fieldID, sbyte value);
		/// <inheritdoc cref="SetObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetCharField(IntPtr obj, IntPtr fieldID, char value);
		/// <inheritdoc cref="SetObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetShortField(IntPtr obj, IntPtr fieldID, short value);
		/// <inheritdoc cref="SetObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetIntField(IntPtr obj, IntPtr fieldID, int value);
		/// <inheritdoc cref="SetObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetLongField(IntPtr obj, IntPtr fieldID, long value);
		/// <inheritdoc cref="SetObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetFloatField(IntPtr obj, IntPtr fieldID, float value);
		/// <inheritdoc cref="SetObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetDoubleField(IntPtr obj, IntPtr fieldID, double value);

		/// <summary>
		/// Returns the method ID for a static method of a class.
		/// </summary>
		/// <param name="clazz">A Java class object.</param>
		/// <param name="name">The static method name.</param>
		/// <param name="sig">The method signature.</param>
		/// <returns>A method ID, or <see cref="IntPtr.Zero" /> if the operation fails.</returns>
		/// <remarks>
		/// <para>The method is specified by its name and signature.</para>
		/// <para><see cref="GetStaticMethodID(IntPtr, string, string)" /> causes an uninitialized class to be initialized.</para>
		/// </remarks>
		IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig);

		/// <summary>
		/// Invokes a static method on a Java object, according to the specified method ID.
		/// </summary>
		/// <param name="clazz">A Java object.</param>
		/// <param name="methodID">A static method ID.</param>
		/// <param name="args">An array of arguments.</param>
		/// <returns>The result of calling the static Java method.</returns>
		/// <remarks>
		/// <para>The method ID must be derived from <paramref name="clazz" />, not from one of its superclasses.</para>
		/// </remarks>
		IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallStaticObjectMethod(IntPtr, IntPtr, JniValue[])" />
		bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallStaticObjectMethod(IntPtr, IntPtr, JniValue[])" />
		sbyte CallStaticByteMethod(IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallStaticObjectMethod(IntPtr, IntPtr, JniValue[])" />
		char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallStaticObjectMethod(IntPtr, IntPtr, JniValue[])" />
		short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallStaticObjectMethod(IntPtr, IntPtr, JniValue[])" />
		int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallStaticObjectMethod(IntPtr, IntPtr, JniValue[])" />
		long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallStaticObjectMethod(IntPtr, IntPtr, JniValue[])" />
		float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallStaticObjectMethod(IntPtr, IntPtr, JniValue[])" />
		double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, JniValue[] args);
		/// <inheritdoc cref="CallStaticObjectMethod(IntPtr, IntPtr, JniValue[])" />
		void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, JniValue[] args);

		/// <summary>
		/// Returns the field ID for a static field of a class.
		/// </summary>
		/// <param name="clazz">A Java class object.</param>
		/// <param name="name">The static field name.</param>
		/// <param name="sig">The field signature.</param>
		/// <returns>A field ID, or <see cref="IntPtr.Zero" /> if the specified static field cannot be found.</returns>
		/// <remarks>
		/// <para>The field is specified by its name and signature. The <see cref="GetStaticObjectField(IntPtr, IntPtr)" /> and <see cref="SetStaticObjectField(IntPtr, IntPtr, IntPtr)" /> families of accessor functions use field IDs to retrieve static fields.</para>
		/// <para><see cref="GetStaticFieldID(IntPtr, string, string)" /> causes an uninitialized class to be initialized.</para>
		/// </remarks>
		IntPtr GetStaticFieldID(IntPtr clazz, string name, string sig);

		/// <summary>
		/// Returns the value of a static field of an object.
		/// </summary>
		/// <param name="clazz">A Java class object.</param>
		/// <param name="fieldID">A static field ID.</param>
		/// <returns>The content of the static field.</returns>
		/// <remarks>
		/// <para>The field to access is specified by a field ID, which is obtained by calling <see cref="GetStaticFieldID(IntPtr, string, string)" />.</para>
		/// </remarks>
		IntPtr GetStaticObjectField(IntPtr clazz, IntPtr fieldID);
		/// <inheritdoc cref="GetStaticObjectField(IntPtr, IntPtr)" />
		bool GetStaticBooleanField(IntPtr clazz, IntPtr fieldID);
		/// <inheritdoc cref="GetStaticObjectField(IntPtr, IntPtr)" />
		sbyte GetStaticByteField(IntPtr clazz, IntPtr fieldID);
		/// <inheritdoc cref="GetStaticObjectField(IntPtr, IntPtr)" />
		char GetStaticCharField(IntPtr clazz, IntPtr fieldID);
		/// <inheritdoc cref="GetStaticObjectField(IntPtr, IntPtr)" />
		short GetStaticShortField(IntPtr clazz, IntPtr fieldID);
		/// <inheritdoc cref="GetStaticObjectField(IntPtr, IntPtr)" />
		int GetStaticIntField(IntPtr clazz, IntPtr fieldID);
		/// <inheritdoc cref="GetStaticObjectField(IntPtr, IntPtr)" />
		long GetStaticLongField(IntPtr clazz, IntPtr fieldID);
		/// <inheritdoc cref="GetStaticObjectField(IntPtr, IntPtr)" />
		float GetStaticFloatField(IntPtr clazz, IntPtr fieldID);
		/// <inheritdoc cref="GetStaticObjectField(IntPtr, IntPtr)" />
		double GetStaticDoubleField(IntPtr clazz, IntPtr fieldID);

		/// <summary>
		/// Sets the value of a static field of an object.
		/// </summary>
		/// <param name="clazz">A Java class object.</param>
		/// <param name="fieldID">A static field ID.</param>
		/// <param name="value">The new value of the field.</param>
		/// <remarks>
		/// <para>The field to access is specified by a field ID, which is obtained by calling <see cref="GetStaticFieldID(IntPtr, string, string)" />.</para>
		/// </remarks>
		void SetStaticObjectField(IntPtr clazz, IntPtr fieldID, IntPtr value);
		/// <inheritdoc cref="SetStaticObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetStaticBooleanField(IntPtr clazz, IntPtr fieldID, bool value);
		/// <inheritdoc cref="SetStaticObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetStaticByteField(IntPtr clazz, IntPtr fieldID, sbyte value);
		/// <inheritdoc cref="SetStaticObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetStaticCharField(IntPtr clazz, IntPtr fieldID, char value);
		/// <inheritdoc cref="SetStaticObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetStaticShortField(IntPtr clazz, IntPtr fieldID, short value);
		/// <inheritdoc cref="SetStaticObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetStaticIntField(IntPtr clazz, IntPtr fieldID, int value);
		/// <inheritdoc cref="SetStaticObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetStaticLongField(IntPtr clazz, IntPtr fieldID, long value);
		/// <inheritdoc cref="SetStaticObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetStaticFloatField(IntPtr clazz, IntPtr fieldID, float value);
		/// <inheritdoc cref="SetStaticObjectField(IntPtr, IntPtr, IntPtr)" />
		void SetStaticDoubleField(IntPtr clazz, IntPtr fieldID, double value);

		/// <summary>
		/// Constructs a new <c>java.lang.String</c> object from an array of Unicode characters.
		/// </summary>
		/// <param name="unicodeChars">A pointer to a Unicode string.</param>
		/// <param name="len">Length of the Unicode string.</param>
		/// <returns>A Java string object, or <see cref="IntPtr.Zero" /> if the string cannot be constructed.</returns>
		IntPtr NewString(char* unicodeChars, int len);
		/// <summary>
		/// Returns the length (the count of Unicode characters) of a Java string.
		/// </summary>
		/// <param name="string">A Java string object.</param>
		/// <returns>The length of the Java string.</returns>
		int GetStringLength(IntPtr @string);
		/// <summary>
		/// Returns a pointer to the array of Unicode characters of the string.
		/// </summary>
		/// <param name="string">A Java string object.</param>
		/// <param name="isCopy">Set to <see langword="true" /> if a copy is made; or set to <see langword="false" /> if no copy is made.</param>
		/// <returns>A pointer to a Unicode string, or <see cref="IntPtr.Zero" /> if the operation fails.</returns>
		/// <remarks>
		/// <para>The returned pointer is valid until <see cref="ReleaseStringChars(IntPtr, char*)" /> is called.</para>
		/// </remarks>
		char* GetStringChars(IntPtr @string, out bool isCopy);
		/// <summary>
		/// Informs the VM that the native code no longer needs access to <paramref name="chars" />.
		/// </summary>
		/// <param name="string">A Java string object.</param>
		/// <param name="chars">A pointer to a Unicode string.</param>
		/// <remarks>
		/// <para>The <paramref name="chars" /> argument is a pointer obtained from string using <see cref="GetStringChars(IntPtr, out bool)" />.</para>
		/// </remarks>
		void ReleaseStringChars(IntPtr @string, char* chars);
		/// <summary>
		/// Constructs a new <c>java.lang.String</c> object from an array of characters in modified UTF-8 encoding.
		/// </summary>
		/// <param name="bytes">The pointer to a modified UTF-8 string.</param>
		/// <returns>A Java string object, or <see cref="IntPtr.Zero" /> if the string cannot be constructed.</returns>
		IntPtr NewStringUTF(byte* bytes);
		/// <summary>
		/// Returns the length in bytes of the modified UTF-8 representation of a string.
		/// </summary>
		/// <param name="string">A Java string object.</param>
		/// <returns>Returns the UTF-8 length of the string.</returns>
		int GetStringUTFLength(IntPtr @string);
		/// <summary>
		/// Returns a pointer to an array of bytes representing the string in modified UTF-8 encoding.
		/// </summary>
		/// <param name="string">A Java string object.</param>
		/// <param name="isCopy">Set to <see langword="true" /> if a copy is made; or set to <see langword="false" /> if no copy is made.</param>
		/// <returns>A pointer to a modified UTF-8 string, or <see cref="IntPtr.Zero" /> if the operation fails.</returns>
		/// <remarks>
		/// <para>The returned array is valid until it is released by <see cref="ReleaseStringUTFChars(char*, byte*)" />.</para>
		/// </remarks>
		byte* GetStringUTFChars(IntPtr @string, out bool isCopy);
		/// <summary>
		/// Informs the VM that the native code no longer needs access to <paramref name="utf" />.
		/// </summary>
		/// <param name="string">A Java string object.</param>
		/// <param name="utf">A pointer to a modified UTF-8 string.</param>
		/// <remarks>
		/// <para>The <paramref name="utf" /> argument is a pointer derived from string using <see cref="GetStringUTFChars(IntPtr, out bool)" />.</para>
		/// </remarks>
		void ReleaseStringUTFChars(char* @string, byte* utf);
		/// <summary>
		/// Returns the number of elements in the array.
		/// </summary>
		/// <param name="array">A Java array object.</param>
		/// <returns>The length of the array.</returns>
		int GetArrayLength(IntPtr array);
		/// <summary>
		/// Constructs a new array holding objects in class <paramref name="elementClass" />.
		/// </summary>
		/// <param name="length">Array size.</param>
		/// <param name="elementClass">Array element class.</param>
		/// <param name="initialElement">Initialization value.</param>
		/// <returns>A Java array object, or <see cref="IntPtr.Zero" /> if the array cannot be constructed.</returns>
		/// <remarks>
		/// <para>All elements are initially set to <paramref name="initialElement" />.</para>
		/// </remarks>
		IntPtr NewObjectArray(int length, IntPtr elementClass, IntPtr initialElement);
		/// <summary>
		/// Returns an element of an <c>Object</c> array.
		/// </summary>
		/// <param name="array">A Java array.</param>
		/// <param name="index">Array index.</param>
		/// <returns>A Java object.</returns>
		IntPtr GetObjectArrayElement(IntPtr array, int index);
		/// <summary>
		/// Sets an element of an <c>Object</c> array.
		/// </summary>
		/// <param name="array">A Java array.</param>
		/// <param name="index">Array index.</param>
		/// <param name="value">The new value.</param>
		void SetObjectArrayElement(IntPtr array, int index, IntPtr value);

		/// <inheritdoc cref="NewIntArray(int)" />
		IntPtr NewBooleanArray(int length);
		/// <inheritdoc cref="NewIntArray(int)" />
		IntPtr NewByteArray(int length);
		/// <inheritdoc cref="NewIntArray(int)" />
		IntPtr NewCharArray(int length);
		/// <inheritdoc cref="NewIntArray(int)" />
		IntPtr NewShortArray(int length);
		/// <summary>
		/// Constructs a new primitive array object.
		/// </summary>
		/// <param name="length">The array length.</param>
		/// <returns>A Java array, or <see cref="IntPtr.Zero" /> if the array cannot be constructed.</returns>
		IntPtr NewIntArray(int length);
		/// <inheritdoc cref="NewIntArray(int)" />
		IntPtr NewLongArray(int length);
		/// <inheritdoc cref="NewIntArray(int)" />
		IntPtr NewFloatArray(int length);
		/// <inheritdoc cref="NewIntArray(int)" />
		IntPtr NewDoubleArray(int length);

		/// <inheritdoc cref="GetIntArrayElements(IntPtr, out bool)" />
		bool* GetBooleanArrayElements(IntPtr array, out bool isCopy);
		/// <inheritdoc cref="GetIntArrayElements(IntPtr, out bool)" />
		sbyte* GetByteArrayElements(IntPtr array, out bool isCopy);
		/// <inheritdoc cref="GetIntArrayElements(IntPtr, out bool)" />
		char* GetCharArrayElements(IntPtr array, out bool isCopy);
		/// <inheritdoc cref="GetIntArrayElements(IntPtr, out bool)" />
		short* GetShortArrayElements(IntPtr array, out bool isCopy);
		/// <summary>
		/// Returns the body of the primitive array.
		/// </summary>
		/// <param name="array">A Java array.</param>
		/// <param name="isCopy">Set to <see langword="true" /> if a copy is made; or set to <see langword="false" /> if no copy is made.</param>
		/// <returns>A pointer to the array elements, or <see cref="IntPtr.Zero" /> if the operation fails.</returns>
		/// <remarks>
		/// <para>The result is valid until the corresponding <see cref="ReleaseIntArrayElements(IntPtr, int*, JniReleaseArrayElementsMode)" /> function is called. Since the returned array may be a copy of the Java array, changes made to the returned array will not necessarily be reflected in the original array until <see cref="ReleaseIntArrayElements(IntPtr, int*, JniReleaseArrayElementsMode)" /> is called.</para>
		/// </remarks>
		int* GetIntArrayElements(IntPtr array, out bool isCopy);
		/// <inheritdoc cref="GetIntArrayElements(IntPtr, out bool)" />
		long* GetLongArrayElements(IntPtr array, out bool isCopy);
		/// <inheritdoc cref="GetIntArrayElements(IntPtr, out bool)" />
		float* GetFloatArrayElements(IntPtr array, out bool isCopy);
		/// <inheritdoc cref="GetIntArrayElements(IntPtr, out bool)" />
		double* GetDoubleArrayElements(IntPtr array, out bool isCopy);

		/// <inheritdoc cref="ReleaseIntArrayElements(IntPtr, int*, JniReleaseArrayElementsMode)" />
		void ReleaseBooleanArrayElements(IntPtr array, bool* elems, JniReleaseArrayElementsMode mode);
		/// <inheritdoc cref="ReleaseIntArrayElements(IntPtr, int*, JniReleaseArrayElementsMode)" />
		void ReleaseByteArrayElements(IntPtr array, sbyte* elems, JniReleaseArrayElementsMode mode);
		/// <inheritdoc cref="ReleaseIntArrayElements(IntPtr, int*, JniReleaseArrayElementsMode)" />
		void ReleaseCharArrayElements(IntPtr array, char* elems, JniReleaseArrayElementsMode mode);
		/// <inheritdoc cref="ReleaseIntArrayElements(IntPtr, int*, JniReleaseArrayElementsMode)" />
		void ReleaseShortArrayElements(IntPtr array, short* elems, JniReleaseArrayElementsMode mode);
		/// <summary>
		/// Informs the VM that the native code no longer needs access to <paramref name="elems" />.
		/// </summary>
		/// <param name="array">A Java array object.</param>
		/// <param name="elems">A pointer to array elements.</param>
		/// <param name="mode">The release mode.</param>
		/// <remarks>
		/// <para>The <paramref name="elems" /> argument is a pointer derived from array using the corresponding <see cref="GetIntArrayElements(IntPtr, out bool)" /> function. If necessary, this function copies back all changes made to <paramref name="elems" /> to the original array.</para>
		/// <para>The <paramref name="mode" /> argument provides information on how the array buffer should be released. <paramref name="mode" /> has no effect if <paramref name="elems" /> is not a copy of the elements in <paramref name="array" />.</para>
		/// <para>In most cases, programmers pass <see cref="JniReleaseArrayElementsMode.Default" /> to the mode argument to ensure consistent behavior for both pinned and copied arrays. The other options give the programmer more control over memory management and should be used with extreme care.</para>
		/// </remarks>
		void ReleaseIntArrayElements(IntPtr array, int* elems, JniReleaseArrayElementsMode mode);
		/// <inheritdoc cref="ReleaseIntArrayElements(IntPtr, int*, JniReleaseArrayElementsMode)" />
		void ReleaseLongArrayElements(IntPtr array, long* elems, JniReleaseArrayElementsMode mode);
		/// <inheritdoc cref="ReleaseIntArrayElements(IntPtr, int*, JniReleaseArrayElementsMode)" />
		void ReleaseFloatArrayElements(IntPtr array, float* elems, JniReleaseArrayElementsMode mode);
		/// <inheritdoc cref="ReleaseIntArrayElements(IntPtr, int*, JniReleaseArrayElementsMode)" />
		void ReleaseDoubleArrayElements(IntPtr array, double* elems, JniReleaseArrayElementsMode mode);

		/// <inheritdoc cref="GetIntArrayRegion(IntPtr, int, int, int*)" />
		void GetBooleanArrayRegion(IntPtr array, int start, int len, bool* buf);
		/// <inheritdoc cref="GetIntArrayRegion(IntPtr, int, int, int*)" />
		void GetByteArrayRegion(IntPtr array, int start, int len, sbyte* buf);
		/// <inheritdoc cref="GetIntArrayRegion(IntPtr, int, int, int*)" />
		void GetCharArrayRegion(IntPtr array, int start, int len, char* buf);
		/// <inheritdoc cref="GetIntArrayRegion(IntPtr, int, int, int*)" />
		void GetShortArrayRegion(IntPtr array, int start, int len, short* buf);
		/// <summary>
		/// Copies a region of a primitive array into a buffer.
		/// </summary>
		/// <param name="array">A Java array.</param>
		/// <param name="start">The starting index.</param>
		/// <param name="len">The number of elements to be copied.</param>
		/// <param name="buf">The destination buffer.</param>
		void GetIntArrayRegion(IntPtr array, int start, int len, int* buf);
		/// <inheritdoc cref="GetIntArrayRegion(IntPtr, int, int, int*)" />
		void GetLongArrayRegion(IntPtr array, int start, int len, long* buf);
		/// <inheritdoc cref="GetIntArrayRegion(IntPtr, int, int, int*)" />
		void GetFloatArrayRegion(IntPtr array, int start, int len, float* buf);
		/// <inheritdoc cref="GetIntArrayRegion(IntPtr, int, int, int*)" />
		void GetDoubleArrayRegion(IntPtr array, int start, int len, double* buf);

		/// <inheritdoc cref="SetIntArrayRegion(IntPtr, int, int, int*)" />
		void SetBooleanArrayRegion(IntPtr array, int start, int len, bool* buf);
		/// <inheritdoc cref="SetIntArrayRegion(IntPtr, int, int, int*)" />
		void SetByteArrayRegion(IntPtr array, int start, int len, sbyte* buf);
		/// <inheritdoc cref="SetIntArrayRegion(IntPtr, int, int, int*)" />
		void SetCharArrayRegion(IntPtr array, int start, int len, char* buf);
		/// <inheritdoc cref="SetIntArrayRegion(IntPtr, int, int, int*)" />
		void SetShortArrayRegion(IntPtr array, int start, int len, short* buf);
		/// <summary>
		/// Copies back a region of a primitive array from a buffer.
		/// </summary>
		/// <param name="array">A Java array.</param>
		/// <param name="start">The starting index.</param>
		/// <param name="len">The number of elements to be copied.</param>
		/// <param name="buf">The source buffer.</param>
		void SetIntArrayRegion(IntPtr array, int start, int len, int* buf);
		/// <inheritdoc cref="SetIntArrayRegion(IntPtr, int, int, int*)" />
		void SetLongArrayRegion(IntPtr array, int start, int len, long* buf);
		/// <inheritdoc cref="SetIntArrayRegion(IntPtr, int, int, int*)" />
		void SetFloatArrayRegion(IntPtr array, int start, int len, float* buf);
		/// <inheritdoc cref="SetIntArrayRegion(IntPtr, int, int, int*)" />
		void SetDoubleArrayRegion(IntPtr array, int start, int len, double* buf);

		/// <summary>
		/// Registers native methods with the class specified by the <paramref name="clazz" /> argument.
		/// </summary>
		/// <param name="clazz">A Java class object.</param>
		/// <param name="methods">The native methods in the class.</param>
		/// <exception cref="JniException">On failure.</exception>
		/// <remarks>
		/// <para>The <paramref name="methods" /> parameter specifies an array of <see cref="JniNativeMethod" /> structures that contain the names, signatures, and function pointers of the native methods.</para>
		/// </remarks>
		void RegisterNatives(IntPtr clazz, JniNativeMethod[] methods);
		/// <summary>
		/// Unregisters native methods of a class.
		/// </summary>
		/// <param name="clazz">A Java class object.</param>
		/// <exception cref="JniException">On failure.</exception>
		/// <remarks>
		/// <para>The class goes back to the state before it was linked or registered with its native method functions.</para>
		/// <para>This function should not be used in normal native code. Instead, it provides special programs a way to reload and relink native libraries.</para>
		/// </remarks>
		void UnregisterNatives(IntPtr clazz);
		/// <summary>
		/// Enters the monitor associated with the underlying Java object referred to by <paramref name="obj" />.
		/// </summary>
		/// <param name="obj">A normal Java object or class object.</param>
		/// <exception cref="JniException">On failure.</exception>
		/// <remarks>
		/// <para>Enters the monitor associated with the object referred to by <paramref name="obj" />. The <paramref name="obj" /> reference must not be <see cref="IntPtr.Zero" />.</para>
		/// <para>Each Java object has a monitor associated with it. If the current thread already owns the monitor associated with <paramref name="obj" />, it increments a counter in the monitor indicating the number of times this thread has entered the monitor. If the monitor associated with <paramref name="obj" /> is not owned by any thread, the current thread becomes the owner of the monitor, setting the entry count of this monitor to 1. If another thread already owns the monitor associated with <paramref name="obj" />, the current thread waits until the monitor is released, then tries again to gain ownership.</para>
		/// </remarks>
		void MonitorEnter(IntPtr obj);
		/// <summary>
		/// Exits the monitor associated with the underlying Java object referred to by <paramref name="obj" />.
		/// </summary>
		/// <param name="obj">A normal Java object or class object.</param>
		/// <exception cref="JniException">On failure.</exception>
		/// <remarks>
		/// <para>The current thread must be the owner of the monitor associated with the underlying Java object referred to by <paramref name="obj" />. The thread decrements the counter indicating the number of times it has entered this monitor. If the value of the counter becomes zero, the current thread releases the monitor.</para>
		/// <para>Native code must not use <see cref="MonitorExit(IntPtr)" /> to exit a monitor entered through a synchronized method or a <c>monitorenter</c> Java virtual machine instruction.</para>
		/// </remarks>
		void MonitorExit(IntPtr obj);
		/// <summary>
		/// Returns the Java VM interface (used in the Invocation API) associated with the current thread.
		/// </summary>
		/// <param name="vm">The result.</param>
		/// <exception cref="JniException">On failure.</exception>
		void GetJavaVM(out IJniInvoke vm);

		/// <summary>
		/// Copies <paramref name="len" /> number of Unicode characters beginning at offset <paramref name="start" /> to the given buffer <paramref name="buf" />.
		/// </summary>
		/// <param name="str">A Java string object.</param>
		/// <param name="start">The offset where the copy starts.</param>
		/// <param name="len">The number of characters to be copied.</param>
		/// <param name="buf">The destination buffer.</param>
		/// <remarks>
		/// <para>Throws <c>StringIndexOutOfBoundsException</c> on index overflow.</para>
		/// </remarks>
		void GetStringRegion(IntPtr str, int start, int len, char* buf);
		/// <summary>
		/// Translates <paramref name="len" /> number of Unicode characters beginning at offset <paramref name="start" /> into modified UTF-8 encoding and place the result in the given buffer <paramref name="buf" />.
		/// </summary>
		/// <param name="str">A Java string object.</param>
		/// <param name="start">The offset where the translation starts.</param>
		/// <param name="len">The number of characters to be translated.</param>
		/// <param name="buf">The destination buffer.</param>
		/// <remarks>
		/// <para>Throws <c>StringIndexOutOfBoundsException</c> on index overflow.</para>
		/// </remarks>
		void GetStringUTFRegion(IntPtr str, int start, int len, byte* buf);

		/// <summary>
		/// Returns the body of the primitive array.
		/// </summary>
		/// <param name="array">A Java array.</param>
		/// <param name="isCopy">Set to <see langword="true" /> if a copy is made; or set to <see langword="false" /> if no copy is made.</param>
		/// <returns>A pointer to the array elements, or <see cref="IntPtr.Zero" /> if the operation fails.</returns>
		/// <remarks>
		/// <para>The result is valid until the corresponding <see cref="ReleasePrimitiveArrayCritical(IntPtr, IntPtr, JniReleaseArrayElementsMode)" /> function is called. Since the returned array may be a copy of the Java array, changes made to the returned array will not necessarily be reflected in the original array until <see cref="ReleasePrimitiveArrayCritical(IntPtr, IntPtr, JniReleaseArrayElementsMode)" /> is called.</para>
		/// <para>There are significant restrictions on how this function can be used. After calling <see cref="GetPrimitiveArrayCritical(IntPtr, out bool)" />, the native code should not run for an extended period of time before it calls <see cref="ReleasePrimitiveArrayCritical(IntPtr, IntPtr, JniReleaseArrayElementsMode)" />. We must treat the code inside this pair of functions as running in a "critical region." Inside a critical region, native code must not call other JNI functions, or any system call that may cause the current thread to block and wait for another Java thread. (For example, the current thread must not call <c>read</c> on a stream being written by another Java thread.)</para>
		/// <para>These restrictions make it more likely that the native code will obtain an uncopied version of the array, even if the VM does not support pinning. For example, a VM may temporarily disable garbage collection when the native code is holding a pointer to an array obtained via <see cref="GetPrimitiveArrayCritical(IntPtr, out bool)" />.</para>
		/// <para>Multiple pairs of <see cref="GetPrimitiveArrayCritical(IntPtr, out bool)" /> and <see cref="ReleasePrimitiveArrayCritical(IntPtr, IntPtr, JniReleaseArrayElementsMode)" /> may be nested.</para>
		/// <para>Note that <see cref="GetPrimitiveArrayCritical(IntPtr, out bool)" /> might still make a copy of the array if the VM internally represents arrays in a different format. Therefore we need to check its return value against <see cref="IntPtr.Zero" /> for possible out of memory situations.</para>
		/// </remarks>
		IntPtr GetPrimitiveArrayCritical(IntPtr array, out bool isCopy);
		/// <summary>
		/// Informs the VM that the native code no longer needs access to <paramref name="carray" />.
		/// </summary>
		/// <param name="array">A Java array object.</param>
		/// <param name="carray">A pointer to array elements.</param>
		/// <param name="mode">The release mode.</param>
		/// <remarks>
		/// <para>The <paramref name="carray" /> argument is a pointer derived from array using the corresponding <see cref="GetPrimitiveArrayCritical(IntPtr, out bool)" /> function. If necessary, this function copies back all changes made to <paramref name="carray" /> to the original array.</para>
		/// <para>The <paramref name="mode" /> argument provides information on how the array buffer should be released. <paramref name="mode" /> has no effect if <paramref name="carray" /> is not a copy of the elements in <paramref name="array" />.</para>
		/// <para>In most cases, programmers pass <see cref="JniReleaseArrayElementsMode.Default" /> to the mode argument to ensure consistent behavior for both pinned and copied arrays. The other options give the programmer more control over memory management and should be used with extreme care.</para>
		/// <para>There are significant restrictions on how this function can be used. After calling <see cref="GetPrimitiveArrayCritical(IntPtr, out bool)" />, the native code should not run for an extended period of time before it calls <see cref="ReleasePrimitiveArrayCritical(IntPtr, IntPtr, JniReleaseArrayElementsMode)" />. We must treat the code inside this pair of functions as running in a "critical region." Inside a critical region, native code must not call other JNI functions, or any system call that may cause the current thread to block and wait for another Java thread. (For example, the current thread must not call <c>read</c> on a stream being written by another Java thread.)</para>
		/// <para>These restrictions make it more likely that the native code will obtain an uncopied version of the array, even if the VM does not support pinning. For example, a VM may temporarily disable garbage collection when the native code is holding a pointer to an array obtained via <see cref="GetPrimitiveArrayCritical(IntPtr, out bool)" />.</para>
		/// <para>Multiple pairs of <see cref="GetPrimitiveArrayCritical(IntPtr, out bool)" /> and <see cref="ReleasePrimitiveArrayCritical(IntPtr, IntPtr, JniReleaseArrayElementsMode)" /> may be nested.</para>
		/// <para>Note that <see cref="GetPrimitiveArrayCritical(IntPtr, out bool)" /> might still make a copy of the array if the VM internally represents arrays in a different format. Therefore we need to check its return value against <see cref="IntPtr.Zero" /> for possible out of memory situations.</para>
		/// </remarks>
		void ReleasePrimitiveArrayCritical(IntPtr array, IntPtr carray, JniReleaseArrayElementsMode mode);

		/// <summary>
		/// Returns a pointer to the array of Unicode characters of the string.
		/// </summary>
		/// <param name="string">A Java string object.</param>
		/// <param name="isCopy">Set to <see langword="true" /> if a copy is made; or it is set to <see langword="false" /> if no copy is made.</param>
		/// <returns>A pointer to a Unicode string, or <see cref="IntPtr.Zero" /> if the operation fails.</returns>
		/// <remarks>
		/// <para>The returned pointer is valid until <see cref="ReleaseStringChars(IntPtr, char*)" /> is called.</para>
		/// <para>There are significant restrictions on how this function can be used. In a code segment enclosed by <see cref="GetStringCritical(IntPtr, out bool)" /> and <see cref="ReleaseStringCritical(IntPtr, char*)" /> calls, the native code must not issue arbitrary JNI calls, or cause the current thread to block.</para>
		/// </remarks>
		char* GetStringCritical(IntPtr @string, out bool isCopy);
		/// <summary>
		/// Informs the VM that the native code no longer needs access to <paramref name="carray" />.
		/// </summary>
		/// <param name="string">A Java string object.</param>
		/// <param name="carray">A pointer to a Unicode string.</param>
		/// <remarks>
		/// <para>The <paramref name="carray" /> argument is a pointer obtained from string using <see cref="GetStringChars(IntPtr, out bool)" />.</para>
		/// <para>There are significant restrictions on how this function can be used. In a code segment enclosed by <see cref="GetStringCritical(IntPtr, out bool)" /> and <see cref="ReleaseStringCritical(IntPtr, char*)" /> calls, the native code must not issue arbitrary JNI calls, or cause the current thread to block.</para>
		/// </remarks>
		void ReleaseStringCritical(IntPtr @string, char* carray);

		/// <summary>
		/// Creates a new weak global reference.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns>A new weak global reference. <see cref="IntPtr.Zero" /> if <paramref name="obj" /> refers to <c>null</c>, or if the VM runs out of memory.</returns>
		/// <remarks>
		/// <para>If the VM runs out of memory, an <c>OutOfMemoryError</c> will be thrown.</para>
		/// </remarks>
		IntPtr NewWeakGlobalRef(IntPtr obj);
		/// <summary>
		/// Delete the VM resources needed for the given weak global reference.
		/// </summary>
		/// <param name="obj">The weak global reference.</param>
		void DeleteWeakGlobalRef(IntPtr obj);

		/// <summary>
		/// Checks whether there is a pending exception.
		/// </summary>
		/// <returns><see langword="true" /> when there is a pending exception; otherwise, <see langword="false" />.</returns>
		/// <remarks>Identical to <see cref="ExceptionOccurred" />, but without creating a local reference to the exception object.</remarks>
		bool ExceptionCheck();

		/// <summary>
		/// Allocates and returns a direct <c>java.nio.ByteBuffer</c> referring to the block of memory starting at the memory address <paramref name="address" /> and extending <paramref name="capacity" /> bytes.
		/// </summary>
		/// <param name="address">The starting address of the memory region (must not be <see langword="null" />).</param>
		/// <param name="capacity">The size in bytes of the memory region (must be positive).</param>
		/// <returns>A local reference to the newly-instantiated <c>java.nio.ByteBuffer</c> object. <see cref="IntPtr.Zero" /> if an exception occurs, or if JNI access to direct buffers is not supported by this virtual machine.</returns>
		/// <remarks>
		/// <para>Native code that calls this function and returns the resulting byte-buffer object to Java-level code should ensure that the buffer refers to a valid region of memory that is accessible for reading and, if appropriate, writing. An attempt to access an invalid memory location from Java code will either return an arbitrary value, have no visible effect, or cause an unspecified exception to be thrown.</para>
		/// </remarks>
		IntPtr NewDirectByteBuffer(void* address, long capacity);
		/// <summary>
		/// Fetches and returns the starting address of the memory region referenced by the given direct <c>java.nio.Buffer</c>.
		/// </summary>
		/// <param name="buf">A direct <c>java.nio.Buffer</c> object (must not be <see cref="IntPtr.Zero" />).</param>
		/// <returns>The starting address of the memory region referenced by the buffer. <see langword="null" /> if the memory region is undefined, if the given object is not a direct <c>java.nio.Buffer</c>, or if JNI access to direct buffers is not supported by this virtual machine.</returns>
		/// <remarks>
		/// <para>This function allows native code to access the same memory region that is accessible to Java code via the buffer object.</para>
		/// </remarks>
		void* GetDirectBufferAddress(IntPtr buf);
		/// <summary>
		/// Fetches and returns the capacity of the memory region referenced by the given direct <c>java.nio.Buffer</c>.
		/// </summary>
		/// <param name="buf">A direct <c>java.nio.Buffer</c> object (must not be <see cref="IntPtr.Zero" />).</param>
		/// <returns>The capacity of the memory region associated with the buffer. <c>-1</c> if the given object is not a direct <c>java.nio.Buffer</c>, if the object is an unaligned view buffer and the processor architecture does not support unaligned access, or if JNI access to direct buffers is not supported by this virtual machine.</returns>
		/// <remarks>
		/// <para>The capacity is the number of elements that the memory region contains.</para>
		/// </remarks>
		long GetDirectBufferCapacity(IntPtr buf);

		/// <summary>
		/// Returns the type of the object referred to by the <paramref name="obj" /> argument.
		/// </summary>
		/// <param name="obj">A local, global or weak global reference.</param>
		/// <returns>One of the enumerated values defined as a <see cref="JniObjectRefType" />.</returns>
		/// <remarks>
		/// <para>If the <paramref name="obj" /> argument is not a valid reference, the return value for this function will be <see cref="JniObjectRefType.Invalid" />. An invalid reference is a reference which is not a valid handle. That is, the <paramref name="obj" /> pointer address does not point to a location in memory which has been allocated from one of the Ref creation functions or returned from a JNI function. As such, <see cref="IntPtr.Zero" /> would be an invalid reference and <see cref="GetObjectRefType(IntPtr)" /> would return <see cref="JniObjectRefType.Invalid" />.</para>
		/// <para>On the other hand, a null reference, which is a reference that points to a <c>null</c>, would return the type of reference that the null reference was originally created as.</para>
		/// <para><see cref="GetObjectRefType(IntPtr)" /> cannot be used on deleted references.</para>
		/// <para>Since references are typically implemented as pointers to memory data structures that can potentially be reused by any of the reference allocation services in the VM, once deleted, it is not specified what value the <see cref="GetObjectRefType(IntPtr)" /> will return.</para>
		/// </remarks>
		JniObjectRefType GetObjectRefType(IntPtr obj);
	}
}

using System;
using System.Runtime.Serialization;

namespace Cryville.Interop.Java {
	/// <summary>
	/// Exception occurring in JNI functions.
	/// </summary>
	[Serializable]
	public class JniException : Exception {
		/// <summary>
		/// The result code returned by the JNI function.
		/// </summary>
		public JniResult JniResult { get; private set; }

		/// <summary>
		/// Creates an instance of the <see cref="JniException" /> class with <see cref="JniResult" /> set to <see cref="JniResult.Unknown" />.
		/// </summary>
		public JniException() : this(JniResult.Unknown) { }
		/// <summary>
		/// Creates an instance of the <see cref="JniException" /> class with <see cref="JniResult" /> set to <see cref="JniResult.Unknown" />.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public JniException(string message) : this(JniResult.Unknown, message) { }
		/// <summary>
		/// Creates an instance of the <see cref="JniException" /> class with <see cref="JniResult" /> set to <see cref="JniResult.Inner" />.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception.</param>
		public JniException(string message, Exception innerException) : this(JniResult.Inner, message, innerException) { }
		/// <summary>
		/// Creates an instance of the <see cref="JniException" /> class with <see cref="JniResult" /> set to <see cref="JniResult.Inner" />.
		/// </summary>
		/// <param name="innerException">The exception that is the cause of the current exception.</param>
		public JniException(Exception innerException) : this(JniResult.Inner, GenerateMessage(JniResult.Inner), innerException) { }
		/// <summary>
		/// Creates an instance of the <see cref="JniException" /> class.
		/// </summary>
		/// <param name="result">The result code returned by the JNI function.</param>
		public JniException(JniResult result) : this(result, GenerateMessage(result)) { }
		/// <summary>
		/// Creates an instance of the <see cref="JniException" /> class.
		/// </summary>
		/// <param name="result">The result code returned by the JNI function.</param>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public JniException(JniResult result, string message) : this(result, message, null) { }
		/// <summary>
		/// Creates an instance of the <see cref="JniException" /> class.
		/// </summary>
		/// <param name="result">The result code returned by the JNI function.</param>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception.</param>
		public JniException(JniResult result, string message, Exception? innerException) : base(message, innerException) {
			JniResult = result;
		}

		static string GenerateMessage(JniResult result) => result switch {
			JniResult.OK => "Success.",
			JniResult.Detached => "Thread detached from the VM.",
			JniResult.Version => "Invalid JNI version.",
			JniResult.NoMemory => "Out of memory.",
			JniResult.Existed => "VM already created.",
			JniResult.Invalid => "Invalid argument.",
			JniResult.Inner => "JNI error.",
			_ => "Unknown error.",
		};

		/// <summary>
		/// Creates an instance of the <see cref="JniException" /> class with serialized data.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="StreamingContext" /> that contains contextual information about the source or destination.</param>
		protected JniException(SerializationInfo info, StreamingContext context) : base(info, context) {
			JniResult = (JniResult)info.GetInt32(nameof(JniResult));
		}
		/// <inheritdoc />
		public override void GetObjectData(SerializationInfo info, StreamingContext context) {
			base.GetObjectData(info, context);
			info.AddValue(nameof(JniResult), (int)JniResult);
		}

		/// <summary>
		/// Checks the result code returned by a JNI function and throws a <see cref="JniException" /> if an error occurred.
		/// </summary>
		/// <param name="result">The result code returned by a JNI function.</param>
		/// <exception cref="JniException">An error occurred.</exception>
		public static void Check(JniResult result) {
			if (result != JniResult.OK) throw new JniException(result);
		}
	}
}

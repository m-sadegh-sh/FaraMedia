namespace FaraMedia.Core {
	using System;
	using System.Runtime.Serialization;

	[Serializable]
	public class FaraException : Exception {
		public FaraException() {}

		public FaraException(string message) : base(message) {}

		public FaraException(string messageFormat,
		                     params object[] args) : base(string.Format(messageFormat,
		                                                                args)) {}

		protected FaraException(SerializationInfo info,
		                        StreamingContext context) : base(info,
		                                                         context) {}

		public FaraException(string message,
		                     Exception innerException) : base(message,
		                                                      innerException) {}
	}
}
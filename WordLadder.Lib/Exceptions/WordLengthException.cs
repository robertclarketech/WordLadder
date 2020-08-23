namespace WordLadder.Lib.Exceptions
{
	using System;
	using System.Runtime.Serialization;

	[Serializable]
	public class WordLengthException : Exception
	{
		public WordLengthException()
		{
		}

		public WordLengthException(string message) : base(message)
		{
		}

		public WordLengthException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected WordLengthException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}

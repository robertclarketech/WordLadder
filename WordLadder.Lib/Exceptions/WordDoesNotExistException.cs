namespace WordLadder.Lib.Exceptions
{
	using System;
	using System.Runtime.Serialization;

	[Serializable]
	public class WordDoesNotExistException : Exception
	{
		public WordDoesNotExistException()
		{
		}

		public WordDoesNotExistException(string message) : base(message)
		{
		}

		public WordDoesNotExistException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected WordDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}

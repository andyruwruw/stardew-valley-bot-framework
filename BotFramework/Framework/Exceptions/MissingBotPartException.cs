using System;

namespace BotFramework.Exceptions
{
    class MissingBotPartException : Exception
    {
		private static string CustomTitle = "Missing Bot Parameter";

		private static string CustomDescription = "You must have all the pieces before you can build your bot!";

		public MissingBotPartException() : base($"{CustomTitle}: ${CustomDescription}")
		{
		}

		public MissingBotPartException(string parameterName) : base($"{CustomTitle} \"${parameterName}\": ${CustomDescription}")
		{
		}

		public MissingBotPartException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}

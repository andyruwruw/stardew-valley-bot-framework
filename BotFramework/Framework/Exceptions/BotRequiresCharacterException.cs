using System;

namespace BotFramework.Exceptions
{
	class BotRequiresCharacterException : Exception
	{
		private static string CustomTitle = "Bot Requires Character";

		private static string CustomDescription = "Your bot doesn't include a Character to attach to!";

		public BotRequiresCharacterException() : base($"{CustomTitle}: ${CustomDescription}")
		{
		}

		public BotRequiresCharacterException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
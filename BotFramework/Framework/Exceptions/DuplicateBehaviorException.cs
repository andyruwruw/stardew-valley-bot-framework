using System;
using BotFramework.Behaviors;

namespace BotFramework.Exceptions
{
    class DuplicateBehaviorException : Exception
	{
		private static string CustomTitle = "Duplicate Behaviors";

		private static string CustomDescription = "Behaviors must have their own unique identifiers.";

		public DuplicateBehaviorException() : base ($"{CustomTitle}: ${CustomDescription}")
		{
		}

		public DuplicateBehaviorException(IBehavior behavior) : base($"{CustomTitle} \"${behavior.GetId()}\": ${CustomDescription}")
		{
		}

		public DuplicateBehaviorException(string id, IBehavior behavior) : base($"{CustomTitle} \"${behavior.GetId()}\" (\"${id}\"): ${CustomDescription}")
		{
		}

		public DuplicateBehaviorException(string message) : base(message)
		{
		}

		public DuplicateBehaviorException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}

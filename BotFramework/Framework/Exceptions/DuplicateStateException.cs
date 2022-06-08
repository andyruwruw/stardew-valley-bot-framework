using System;
using BotFramework.Framework.States;

namespace BotFramework.Exceptions
{
	class DuplicateStateException : Exception
	{
		private static string CustomTitle = "Duplicate States";

		private static string CustomDescription = "States must have their own unique identifiers.";

		public DuplicateStateException() : base($"{CustomTitle}: ${CustomDescription}")
		{
		}

		public DuplicateStateException(IState state) : base($"{CustomTitle} \"${state.GetId()}\": ${CustomDescription}")
		{
		}

		public DuplicateStateException(string id, IState state) : base($"{CustomTitle} \"${state.GetId()}\" (\"${id}\"): ${CustomDescription}")
		{
		}

		public DuplicateStateException(string message) : base(message)
		{
		}

		public DuplicateStateException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
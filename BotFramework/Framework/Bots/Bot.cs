using System;
using BotFramework.Behaviors;
using StardewValley;
using System.Collections.Generic;
using BotFramework.Exceptions;

namespace BotFramework
{
    abstract class Bot : IBot, IEquatable<Bot>
	{
		protected Character _character;

		protected IDictionary<string, Behavior> _behaviors;

		public Bot()
		{
			_character = InitializeCharacter();

			_behaviors = new Dictionary<string, Behavior>();
			IList<Behavior> behaviors = InitializeBehaviors();
			LoadBehaviors(behaviors);

			BotManager.Attatch(this);
		}

		~Bot()
		{
			BotManager.Detatch(this);
		}

		public void Update()
		{

		}

		private void LoadBehaviors(IList<Behavior> behaviors)
		{
			foreach (Behavior behavior in behaviors)
			{
				if (_behaviors.ContainsKey(behavior.GetId()))
				{
					throw new DuplicateBehaviorException(GetId(), behavior);
				}

				_behaviors.Add(behavior.GetId(), behavior);
			}
		}

		public abstract string GetId();

		public Character GetCharacter()
		{
			return _character;
		}

		public IList<Behavior> GetBehaviors()
		{
			return new List<Behavior>(_behaviors.Values);
		}

		public virtual bool Equals(Bot other)
		{
			return _id == other.GetId();
		}
	}
}

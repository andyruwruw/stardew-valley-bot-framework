using System;
using BotFramework.Behaviors;
using StardewValley;
using System.Collections.Generic;
using BotFramework.Exceptions;

namespace BotFramework
{
    class Bot : IBot, IEquatable<Bot>
	{
		private string _id;

		private Character _character;

		private IDictionary<string, Behavior> _behaviors;

		public Bot(
			string id,
			Character character,
			IList<Behavior> behaviors)
		{
			_id = id;
			_character = character;
			_behaviors = new Dictionary<string, Behavior>();

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

		public string GetId()
		{
			return _id;
		}

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

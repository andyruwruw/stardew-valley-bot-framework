using System.Collections.Generic;
using System.Runtime.InteropServices;
using BotFramework.Behaviors;
using BotFramework.Exceptions;
using StardewValley;

namespace BotFramework.Framework.Bots
{
    class BotBuilder
	{
		private string _id;

		private Character _character;

		private IList<Behavior> _behaviors;

		public BotBuilder()
		{
			_behaviors = new List<Behavior>();
		}

		public Bot Build()
		{
			if (_id == null)
			{
				throw new MissingBotPartException("id");
			}

			if (_character == null)
			{
				throw new MissingBotPartException("character");
			}

			if (_behaviors.Count == 0)
			{
				Logger.Debug("You're creating a Bot with no Behaviors, was this intentional?!");
			}

			return new Bot(
				_id,
				_character,
				_behaviors);
		}

		public void SetId(string id)
		{
			_id = id;
		}

		public string GetId()
		{
			return _id;
		}

		public void SetCharacter(Character character)
		{
			_character = character;
		}

		public Character GetCharacter()
		{
			return _character;
		}

		public void SetBehaviors(IList<Behavior> behaviors)
		{
			for (int i = 0; i < behaviors.Count; i++)
			{
				if (behaviors.IndexOf(behaviors[i]) != i)
				{
					DuplicateBehaviorsFound(behaviors[i]);
				}
			}

			_behaviors = behaviors;
		}

		public IList<Behavior> GetBehaviors()
		{
			return _behaviors;
		}

		public void ClearBehaviors()
		{
			_behaviors = new List<Behavior>();
		}

		public void AddBehavior(Behavior behavior)
		{
			if (_behaviors.Contains(behavior))
			{
				DuplicateBehaviorsFound(behavior);
			}

			_behaviors.Add(behavior);
		}

		public void RemoveBehavior(Behavior behavior)
		{
			if (_behaviors.Contains(behavior))
			{
				_behaviors.RemoveAt(_behaviors.IndexOf(behavior));
			}
		}

		public void RemoveBehavior(string id)
		{
			int foundIndex = -1;

			for (int i = 0; i < _behaviors.Count; i++)
			{
				if (_behaviors[i].GetId() == id)
				{
					foundIndex = i;

					break;
				}
			}

			if (foundIndex != -1)
			{
				_behaviors.RemoveAt(foundIndex);
			}
		}

		private void DuplicateBehaviorsFound(Behavior behavior)
		{
			if (_id != null)
			{
				throw new DuplicateBehaviorException(_id, behavior);
			}
			throw new DuplicateBehaviorException(behavior);
		}
	}
}

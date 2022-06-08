using System;
using BotFramework.Behaviors;
using BotFramework.Exceptions;
using System.Collections.Generic;

namespace BotFramework.Framework.States
{
    abstract class State : IState, IEquatable<State>
    {
		protected IDictionary<string, IBehavior> _behaviors;

		public State()
		{
			_behaviors = new Dictionary<string, IBehavior>();
			IList<IBehavior> behaviors = InitializeBehaviors();
			LoadBehaviors(behaviors);
		}

		public abstract bool IsActive();

		protected abstract IList<IBehavior> InitializeBehaviors();

		protected virtual void LoadBehaviors(IList<IBehavior> behaviors)
		{
			foreach (IBehavior behavior in behaviors)
			{
				if (_behaviors.ContainsKey(behavior.GetId()))
				{
					throw new DuplicateBehaviorException(GetId(), behavior);
				}

				_behaviors.Add(behavior.GetId(), behavior);
			}
		}

		public abstract string GetId();

		public virtual string GetDescription()
		{
			return "No description provided.";
		}

		public virtual IList<IBehavior> GetBehaviors()
		{
			return new List<IBehavior>(_behaviors.Values);
		}

		public virtual bool Equals(State other)
		{
			return GetId() == other.GetId();
		}
	}
}

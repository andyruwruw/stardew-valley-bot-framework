using System;
using BotFramework.Targets;

namespace BotFramework.Behaviors
{
    abstract class Behavior : IBehavior, IEquatable<Behavior>
	{
		private string _id;

		private BehaviorType _type;

		private ITarget _target;

		private int _priority;

		public Behavior(
			string id,
			BehaviorType type,
			ITarget target,
			int priority = 0)
		{
			_id = id;
			_type = type;
			_target = target;
			_priority = priority;
		}

		public abstract void InitializeTarget();

		public abstract void InitializeQueryMethod();

		public abstract string GetId();

		public BehaviorType GetType()
		{
			return _type;
		}

		public ITarget GetTarget()
		{
			return _target;
		}

		public int GetPriority()
		{
			return _priority;
		}

		public virtual bool Equals(Behavior other)
		{
			return _id == other.GetId();
		}
	}
}

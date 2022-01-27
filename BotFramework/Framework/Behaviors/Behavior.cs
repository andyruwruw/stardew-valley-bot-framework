using System;
using BotFramework.Targets;

namespace BotFramework.Behaviors
{
  abstract class Behavior : IBehavior, IEquatable<Behavior>
	{
		private BehaviorType _type;

		private ITarget _target;

		private int _priority;

		public Behavior()
		{
			_type = DefaultType();
			_target = DefaultTarget();
			_priority = DefaultPriority();
		}

		protected abstract ITarget DefaultTarget();

		protected virtual BehaviorType DefaultType()
		{
			return BehaviorType.Task;
		}

		protected virtual int DefaultPriority()
		{
			return 0;
		}

		public abstract string GetId();

		public virtual int GetPriority()
		{
			return _priority;
		}

		public virtual void SetPriority(int priority)
		{
			_priority = priority;
		}

		public BehaviorType GetType()
		{
			return _type;
		}

		public ITarget GetTarget()
		{
			return _target;
		}

		public virtual bool Equals(Behavior other)
		{
			return _id == other.GetId();
		}
	}
}

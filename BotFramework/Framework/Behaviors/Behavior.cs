using System;
using BotFramework.Targets;

namespace BotFramework.Behaviors
{
	abstract class Behavior : IBehavior, IEquatable<Behavior>
	{
		private ITarget _target;

		private int _priority;

		public Behavior() 
		{
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

		protected virtual bool PreQueryCondition()
		{
			return true;
		}

		protected virtual bool PostQueryCondition()
		{
			return true;
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
			return GetId() == other.GetId();
		}
	}
}

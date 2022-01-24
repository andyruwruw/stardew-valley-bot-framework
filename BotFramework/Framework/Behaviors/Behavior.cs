﻿using System;
using BotFramework.Targets;

namespace BotFramework.Behaviors
{
    class Behavior : IBehavior, IEquatable<Behavior>
	{
		private string _id;

		private BehaviorType _type;

		private ITarget _stimulus;

		private int _priority;

		public Behavior(
			string id,
			BehaviorType type,
			ITarget stimulus,
			int priority = 0)
		{
			_id = id;
			_type = type;
			_stimulus = stimulus;
			_priority = priority;
		}

		public string GetId()
		{
			return _id;
		}

		public BehaviorType GetType()
		{
			return _type;
		}

		public ITarget GetTarget()
		{
			return _stimulus;
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

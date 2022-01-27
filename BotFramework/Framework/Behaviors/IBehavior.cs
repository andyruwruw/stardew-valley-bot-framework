using BotFramework.Targets;

namespace BotFramework.Behaviors
{
  interface IBehavior
	{
		string GetId();

		int GetPriority();

		void SetPriority(int priority);

		BehaviorType GetType();

		ITarget GetTarget();
	}
}

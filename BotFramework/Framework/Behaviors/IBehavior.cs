using BotFramework.Targets;

namespace BotFramework.Behaviors
{
    interface IBehavior
	{
		string GetId();

		BehaviorType GetType();

		ITarget GetTarget();

		int GetPriority();
	}
}

using BotFramework.Behaviors;
using System.Collections.Generic;

namespace BotFramework.Framework.States
{
    interface IState
    {
		bool IsActive();

		string GetId();

		string GetDescription();

		IList<IBehavior> GetBehaviors();
	}
}

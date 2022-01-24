using BotFramework.Behaviors;
using StardewValley;
using System.Collections.Generic;

namespace BotFramework
{
    interface IBot
	{
		void Update();

		string GetId();

		Character GetCharacter();

		IList<Behavior> GetBehaviors();
	}
}

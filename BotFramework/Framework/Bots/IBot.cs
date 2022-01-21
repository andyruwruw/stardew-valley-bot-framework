using BotFramework.Framework.Behaviors;
using StardewValley;

namespace BotFramework
{
    interface IBot
	{
		Character GetCharacter();

		void SetBehaviors(Behavior[] behaviors);

		Behavior[] GetBehaviors();
	}
}

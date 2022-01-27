using BotFramework.Controllers;
using BotFramework.Framework.States;
using StardewModdingAPI;
using StardewValley;
using System.Collections.Generic;

namespace BotFramework
{
    interface IBot
	{
		void UpdateTicked();

		void DayStarted();

		void ButtonPressed(SButton button);

		void Warped();

		string GetId();

		string GetDescription();

		IController GetController();

		Character GetCharacter();

		IList<IState> GetStates();
	}
}

using BotFramework.Framework.States;
using StardewValley;
using System.Collections.Generic;

namespace BotFramework.Test
{
    class WaterBot : Bot
    {
        public override string GetId()
		{
			return "WaterBot";
		}

        protected override Character DefaultCharacter()
		{
			return Game1.player;
		}

        protected override IList<IState> DefaultStates()
		{
			IList<IState> states = new List<IState>();

			return states;
		}
    }
}

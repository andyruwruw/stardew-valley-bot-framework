using BotFramework.Behaviors;
using StardewValley;
using System.Collections.Generic;

namespace BotFramework.Test
{
    class WaterBot : Bot
    {
		public WaterBot() : base()
		{

		}

		protected override Character InitializeCharacter()
		{
			return Game1.player;
		}

        protected override IList<Behavior> InitializeBehaviors()
		{
			return new List<Behavior>();
		}

        public override string GetId()
		{
			return "WaterBot";
		}
	}
}

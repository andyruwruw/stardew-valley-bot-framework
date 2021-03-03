using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework
{
    class WaterBot : Bot
    {
        public WaterBot() : base(Game1.player)
        {
            List<GameLocation> where = new List<GameLocation>();
            where.Add(Game1.getFarm());

            this.SetLocations(where);
        }

        protected override void PerformAction()
        {

        }
    }
}

using BotFramework.Helpers;
using BotFramework.Locations;
using BotFramework.Targets;
using StardewValley;
using StardewValley.TerrainFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework
{
    class WaterBotTest : Bot
    {
        public WaterBotTest() : base() { }

        public override void DefaultTargets()
        {
            List<ITarget> targets = new List<ITarget>();

            targets.Add(new TargetTile("Waterable", this.Validator, null, action));

            this.SetTargets(targets);
        }

        public override void DefaultLocations()
        {
            List<string> locations = new List<string>();
            locations.Add("Farm");
            locations.Add("BusStop");
            this.SetLocations(locations);
        }

        public bool Validator(Tile tile)
        {
            return tile.GetTerrainFeature() is HoeDirt;
        }

        public void action(Character who, GameLocation where, Tile what)
        {
            LogProxy.Log("Action thing happened");
        }
    }
}

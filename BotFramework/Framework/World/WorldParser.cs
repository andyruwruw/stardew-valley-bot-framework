using BotFramework.Framework.Actionable;
using BotFramework.Framework.Helpers;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework.Framework.World
{
    /// <summary>
    /// Generates graph of warp points for interlocation transit.
    /// </summary>
    class WorldParser
    {
        private List<GameLocation> _locations;
        private List<ActionableLocation> _actionableLocations;
        private List<ActionableLocation> _ordered;

        public WorldParser()
        {
            this._locations = new List<GameLocation>();
        }

        public List<ActionableLocation> GetActionableLocations()
        {
            return this._ordered;
        }

        /// <summary>
        /// Retrieves GameLocation instance based on location name or unique name.
        /// </summary>
        /// 
        /// <param name="locationName">String name or unique name of GameLocation</param>
        /// <returns></returns>
        public GameLocation GetGameLocation(string locationName)
        {
            GameLocation location = Utility.fuzzyLocationSearch(locationName);

            if (location == null)
            {
                throw new Exception($"GameLocation {locationName} not found, please ensure that is a valid value.");
            }

            return location;
        }

        /// <summary>
        /// Sets locations by GameLocation instances.
        /// </summary>
        /// 
        /// <param name="location">List of GameLocation</param>
        public void SetLocations(List<GameLocation> locations)
        {
            this._locations = new List<GameLocation>();
            foreach(GameLocation location in locations)
            {
                this.AddLocation(location);
            }
            this.GenerateActionableLocations();
        }

        /// <summary>
        /// Sets locations by location names or unique names.
        /// </summary>
        /// 
        /// <param name="location">List of location names or unique names</param>
        public void SetLocations(List<string> locations)
        {
            this._locations = new List<GameLocation>();
            foreach (string locationName in locations)
            {
                this.AddLocation(locationName);
            }
            this.GenerateActionableLocations();
        }

        /// <summary>
        /// Appends a single location by GameLocation instance.
        /// </summary>
        /// 
        /// <param name="location">GameLocation instance to add</param>
        private void AddLocation(GameLocation location)
        {
            if (!this._locations.Contains(location))
            {
                this._locations.Add(location);
            }
            else
            {
                LogProxy.Log("WorldParser.AddLocation: Attempt to add location twice was denied.", true);
            }

        }

        /// <summary>
        /// Appends a single location by location name or unique name..
        /// </summary>
        /// 
        /// <param name="location">String name or unique name for location</param>
        private void AddLocation(string locationName)
        {
            GameLocation location = this.GetGameLocation(locationName);

            if (!this._locations.Contains(location))
            {
                this._locations.Add(location);
            }
            else
            {
                LogProxy.Log("WorldParser.AddLocation: Attempt to add location twice was denied.", true);
            }
        }

        private void GenerateActionableLocations()
        {
            this._actionableLocations = new List<ActionableLocation>();
            WorldTour tourGenerator = new WorldTour();
        }
    }
}

using BotFramework.Actions;
using BotFramework.Helpers;
using BotFramework.Locations;
using BotFramework.Targets;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework.World
{
    /// <summary>
    /// Generates graph of warp points for interlocation transit.
    /// </summary>
    class WorldParser : IWorldParser
    {
        private IList<GameLocation> _locations;

        private int _current;
        private IList<ILocationParser> path;

        private IList<ILocationParser> _ordered;

        public WorldParser()
        {
            this._locations = new List<GameLocation>();
        }

        public IList<ILocationParser> GetActionableLocations()
        {
            return this._ordered;
        }

        /// <summary>
        /// Retrieves GameLocation instance based on location name or unique name.
        /// </summary>
        /// 
        /// <param name="locationName">String name or unique name of GameLocation</param>
        /// <returns></returns>
        private GameLocation GetGameLocation(string locationName)
        {
            GameLocation location = Utility.fuzzyLocationSearch(locationName);

            if (location == null)
            {
                throw new Exception($"GameLocation {locationName} not found, please ensure that is a valid value.");
            }

            return location;
        }

        public void SetLocation(GameLocation location)
        {
            this._locations = new List<GameLocation>();
            this.AddLocation(location);
        }

        public void SetLocation(string locationName)
        {
            this._locations = new List<GameLocation>();
            this.AddLocation(this.GetGameLocation(locationName));
        }

        /// <summary>
        /// Sets locations by GameLocation instances.
        /// </summary>
        /// 
        /// <param name="location">List of GameLocation</param>
        public void SetLocations(IList<GameLocation> locations)
        {
            this._locations = new List<GameLocation>();
            foreach(GameLocation location in locations)
            {
                this.AddLocation(location);
            }
        }

        /// <summary>
        /// Sets locations by location names or unique names.
        /// </summary>
        /// 
        /// <param name="location">List of location names or unique names</param>
        public void SetLocations(IList<string> locations)
        {
            this._locations = new List<GameLocation>();
            foreach (string locationName in locations)
            {
                this.AddLocation(locationName);
            }
        }

        /// <summary>
        /// Returns actions based on targets for current location.
        /// </summary>
        /// 
        /// <param name="targets">List of applicable targets for query.</param>
        /// <returns>List of actions</returns>
        public Queue<IAction> GetActions(IList<ITarget> targets)
        {
            return this._ordered[this._current].GetActions(targets);
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
        /// Appends a single location by location name or unique name.
        /// </summary>
        /// 
        /// <param name="location">String name or unique name for location</param>
        private void AddLocation(string locationName)
        {
            this.AddLocation(this.GetGameLocation(locationName));
        }

        public void GenerateActionableLocations(GameLocation current)
        {
            IList<ILocationParser> locationParsers = new List<ILocationParser>();

            foreach(GameLocation location in this._locations)
            {
                locationParsers.Add(new LocationParser(location));
            }

            WorldTour tourGenerator = new WorldTour();

            tourGenerator.SetItems(locationParsers);
            tourGenerator.SetStart(new LocationParser(current));

            tourGenerator.Compute();

            this._ordered = tourGenerator.GetTour();

            foreach(ILocationParser location in this._ordered)
            {
                LogProxy.Log($"LOCATION: {location.GetName()}");
            }

            this._current = 0;
            this.path = new List<ILocationParser>();
        }
    }
}

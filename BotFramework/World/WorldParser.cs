using BotFramework.Actions;
using BotFramework.Helpers;
using BotFramework.Locations;
using BotFramework.Structures;
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
        private Queue<ILocationParser> _path;

        private IList<ILocationParser> _ordered;

        private Graph<ILocationParser> _graph;

        public WorldParser()
        {
            this._locations = new List<GameLocation>();
            this._path = new Queue<ILocationParser>();
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
            this._graph = tourGenerator.GetGraph();

            this._current = 0;
            this._path = new Queue<ILocationParser>();
        }

        /// <summary>
        /// Returns actions based on targets for current location.
        /// </summary>
        /// 
        /// <param name="targets">List of applicable targets for query.</param>
        /// <returns>List of actions</returns>
        public Queue<IAction> GetActions(IList<ITarget> targets, CallOrder type)
        {
            bool isStart = this._current == 0;
            bool startInList = this._locations.Contains(this.GetGameLocation(this._ordered[this._current].GetName()));
            bool currVisited = this._ordered[this._current].GetVisited();
            bool isAtLocationStart = type == CallOrder.AtLocationStart;
            bool itemsInPath = this._path.Count > 0;

            if ((isStart && !startInList) || (currVisited && isAtLocationStart) || itemsInPath)
            {
                if (this._path.Count > 1)
                {
                    return this.ActionToWarp();
                } else
                {
                    this._path.Dequeue();
                }
            }

            if (isAtLocationStart)
            {
                this._ordered[this._current].SetVisited(true);
            }
            return this._ordered[this._current].GetActions(targets);
        }

        private void FindPathToNextLocation()
        {
            this._path = new Queue<ILocationParser>();

            WorldPath pathGenerator = new WorldPath(this._graph);
            pathGenerator.Compute();

            IList<string> path = pathGenerator.GetTour(this._ordered[this._current + 1].GetName());

            for (int i = 1; i < path.Count; i++)
            {
                this._path.Enqueue(new LocationParser(path[i]));
            }

            LogProxy.Info("Path to first actual location");
            foreach (LocationParser location in this._path)
            {
                LogProxy.Info($"Location: {location.GetName()}");
            }
        }

        public Queue<IAction> ActionToWarp()
        {
            Queue<IAction> actions = new Queue<IAction>();

            if (this._path.Count == 0)
            {
                this.FindPathToNextLocation();
            }

            ILocationParser next = this._path.Dequeue();

            IList<Warp> warps = this._ordered[this._current].GetWarps();

            foreach (Warp warp in warps)
            {
                if (warp.TargetName == next.GetName())
                {
                    IAction action = new ActionTile(null, ActionType.Navigate);
                    action.SetStand(this._ordered[this._current].WarpToTile(warp));
                    actions.Enqueue(action);
                    break;
                }
            }

            return actions;
        }
    }
}

﻿using BotFramework.Actions;
using BotFramework.Targets;
using Microsoft.Xna.Framework;
using Netcode;
using StardewValley;
using StardewValley.TerrainFeatures;
using System;
using System.Collections.Generic;

namespace BotFramework.Locations
{
    /// <summary>
    /// Data access object for the GameLocation object.
    /// </summary>
    class LocationParser : ILocationParser
    {
        /// <summary>
        /// GameLocation instace
        /// </summary>
        private GameLocation _location;

        /// <summary>
        /// GameLocation name or unique name
        /// </summary>
        private string _name;

        /// <summary>
        /// Whether or not the map has been loaded
        /// </summary>
        private bool _mapLoaded;

        /// <summary>
        /// Map instance containing all tiles
        /// </summary>
        private Map _map;

        /// <summary>
        /// Whether or not the warp points have been loaded
        /// </summary>
        private bool _warpsLoaded;

        /// <summary>
        /// Warp points for GameLocation
        /// </summary>
        private List<Warp> _warps;

        private bool _visited;

        /// <summary>
        /// Instantiates a LocationParser for a given GameLocation
        /// </summary>
        /// 
        /// <param name="location">GameLocation instance</param>
        public LocationParser(GameLocation location)
        {
            this._location = location;
            this._mapLoaded = false;
            this._map = new Map(this._name);
            this._warpsLoaded = false;
            this._warps = new List<Warp>();
            this._visited = false;

            if (this._location != null)
            {
                this._name = location.NameOrUniqueName;
            }
        }

        /// <summary>
        /// Instantiates a LocationParser for a given GameLocation
        /// </summary>
        /// 
        /// <param name="name">GameLocation name or unique name</param>
        public LocationParser(string name) : this(location: null)
        {
            this._name = name;
        }

        /// <summary>
        /// Retrieve Map instance of location.
        /// </summary>
        /// 
        /// <returns>Map instance of location</returns>
        public Map GetMap()
        {
            if (!this._mapLoaded)
            {
                this.LoadMap();
            }
            return this._map;
        }

        /// <summary>
        /// Retrieve warp points.
        /// </summary>
        /// 
        /// <returns>List of warps</returns>
        public List<Warp> GetWarps()
        {
            if (!this._warpsLoaded)
            {
                this.LoadWarps();
            }
            return this._warps;
        }

        /// <summary>
        /// Retrieve's GameLocation name or unique name.
        /// </summary>
        /// 
        /// <returns>GameLocation name or unique name</returns>
        public string GetName()
        {
            if (this._name == null && this._location != null)
            {
                this._name = this._location.NameOrUniqueName;
            }
            return this._name;
        }

        public bool GetVisited()
        {
            return this._visited;
        }

        public void SetVisited(bool visited)
        {
            this._visited = visited;
        }

        public ITile WarpToTile(Warp warp)
        {
            if (!this._mapLoaded)
            {
                this.LoadMap();
            }

            int X = warp.X < 0 ? 0 : warp.X;
            int Y = warp.Y < 0 ? 0 : warp.Y;

            if (X >= this._map.GetWidth())
            {
                X = this._map.GetWidth();
            }
            if (Y >= this._map.GetHeight())
            {
                Y = this._map.GetHeight();
            }

            return this._map.Get(X, Y);
        }

        public void DisplayMap()
        {
            for (int i = 0; i < this._map.GetHeight(); i++)
            {
                string row = "";
                for (int j = 0; j < this._map.GetWidth(); j++)
                {
                    if (this.TileIsPassable(i, j))
                    {
                        row += "#";
                    } else
                    {
                        row += " ";
                    }
                }
                LogProxy.Info(row);
            }
        }

        public bool TileIsPassable(int X, int Y)
        {
            this.GetLocation();
            return this._location.isCollidingPosition(new Rectangle(Y * 64 + 1, X * 64 + 1, 62, 62), Game1.viewport, isFarmer: true, -1, glider: false, Game1.player);
        }

        /// <summary>
        /// Retrieve GameLocation instance of location.
        /// </summary>
        /// 
        /// <returns>GameLocation instance of location</returns>
        private void GetLocation()
        {
            if (this._location == null)
            {
                this._location = Utility.fuzzyLocationSearch(this._name);

                if (this._location == null)
                {
                    throw new Exception($"GameLocation {this._name} not found, please ensure that is a valid value.");
                }
            }
        }

        /// <summary>
        /// Generates Tile instances for location
        /// </summary>
        private void LoadMap()
        {
            this.GetLocation();

            for (int y = 0; y < this._location.map.Layers[0].LayerHeight; y++)
            {
                for (int x = 0; x < this._location.map.Layers[0].LayerWidth; x++)
                {
                    Vector2 index = new Vector2(y, x);
                    TerrainFeature terrain = null;
                    if (this._location.terrainFeatures.ContainsKey(index))
                    {
                        terrain = this._location.terrainFeatures[index];
                    }
                    this._map.Set(x, y, new Tile(this._name, x, y, terrain));
                }
            }

            this._mapLoaded = true;
        }

        /// <summary>
        /// Loads warps for GameLocation
        /// </summary>
        private void LoadWarps()
        {
            this.GetLocation();

            IList<string> warpNames = new List<string>();
            NetObjectList<Warp> warps = this._location.warps;

            foreach (Warp warp in warps)
            {
                if (!warpNames.Contains(warp.TargetName))
                {
                    this._warps.Add(warp);
                    warpNames.Add(warp.TargetName);
                }
            }

            this._warpsLoaded = true;
        }

        /// <summary>
        /// Retrieves actions for a given set of targets.
        /// </summary>
        /// 
        /// <param name="targets"></param>
        /// <returns></returns>
        public Queue<IAction> GetActions(IList<ITarget> targets)
        {
            Queue<IAction> actions = new Queue<IAction>();

            foreach(ITarget target in targets)
            {
                if (target is TargetAction)
                {

                } else if (target is TargetCharacter)
                {

                } else if (target is TargetObject)
                {

                } else if (target is TargetTile)
                {
                    this.GetTargetTiles(target, actions);
                }
            }

            return actions;
        }

        private void GetTargetTiles(ITarget target, Queue<IAction> actions)
        {
            if (target.GetQueryBehavior() == QueryBehavior.DoForAll)
            {
                // Load map, find all items
            }
            else if (target.GetQueryBehavior() == QueryBehavior.DoForClosest)
            {
                // Breadth-first search
            }
            else if (target.GetQueryBehavior() == QueryBehavior.DoForFarthest)
            {
                // Load map, farthest item
            }
            else if (target.GetQueryBehavior() == QueryBehavior.WithinRange)
            {
                // Breadth-first search
            }
        }

        /// <summary>
        /// Overriden to only check for location name or unique name.
        /// </summary>
        /// 
        /// <param name="obj">Other LocationParser</param>
        /// <returns>Whether same location</returns>
        public override bool Equals(object obj)
        {
            return (obj is LocationParser && ((LocationParser)obj).GetName() == this.GetName());
        }

        /// <summary>
        /// Overriden to hash location name or unique name.
        /// </summary>
        /// 
        /// <returns>Hashed location name or unique name</returns>
        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }
    }
}

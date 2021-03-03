using Netcode;
using StardewValley;
using System;
using System.Collections.Generic;

namespace BotFramework.Framework.Location
{
    /// <summary>
    /// Generates Map instance for a GameLocation
    /// </summary>
    class LocationParser
    {
        private GameLocation _location;
        private string _name;
        private bool _mapLoaded;
        private Map _map;
        private bool _warpsLoaded;
        private List<Warp> _warps;

        public LocationParser(GameLocation location)
        {
            this._location = location;
            this._mapLoaded = false;
            this._map = new Map(this._name);
            this._warpsLoaded = false;
            this._warps = new List<Warp>();

            if (this._location != null)
            {
                this._name = location.NameOrUniqueName;
            }
        }

        public LocationParser(string name):this(location: null)
        {
            this._name = name;
        }

        public LocationParser():this(Game1.currentLocation) { }

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

        public List<Warp> GetWarps()
        {
            if (!this._warpsLoaded)
            {
                this.LoadWarps();
            }
            return this._warps;
        }

        public string GetName()
        {
            if (this._name == null && this._location != null)
            {
                this._name = this._location.NameOrUniqueName;
                
            }
            return this._name;
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
                    this._map.Set(x, y, new Tile(this._name, x, y));
                }
            }

            this._mapLoaded = true;
        }

        private void LoadWarps()
        {
            this.GetLocation();

            NetObjectList<Warp> warps = this._location.warps;

            foreach (Warp warp in warps)
            {
                this._warps.Add(warp);
            }

            this._warpsLoaded = true;
        }
    }
}

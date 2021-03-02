using StardewValley;
using System;

namespace BotFramework.Framework.Location
{
    /// <summary>
    /// Generates Map instance for a GameLocation
    /// </summary>
    class LocationParser
    {
        private string _name;
        private bool _loaded;
        private Map _map;

        public LocationParser(string name)
        {
            this._name = name;
            this._loaded = false;
            this._map = new Map(name);
        }

        public LocationParser()
        {
            this._name = Game1.currentLocation.NameOrUniqueName;
            this._loaded = false;
            this._map = new Map(this._name);
        }

        /// <summary>
        /// Retrieve Map instance of location.
        /// </summary>
        /// 
        /// <returns>Map instance of location</returns>
        public Map GetMap()
        {
            if (!this._loaded)
            {
                this.LoadMap();
            }
            return this._map;
        }

        /// <summary>
        /// Retrieve GameLocation instance of location.
        /// </summary>
        /// 
        /// <returns>GameLocation instance of location</returns>
        private GameLocation GetLocation()
        {
            GameLocation location = Utility.fuzzyLocationSearch(this._name);

            if (location == null)
            {
                throw new Exception($"GameLocation {this._name} not found, please ensure that is a valid value.");
            }

            return location;
        }

        /// <summary>
        /// Generates Tile instances for location
        /// </summary>
        private void LoadMap()
        {
            GameLocation location = this.GetLocation();

            for (int y = 0; y < location.map.Layers[0].LayerHeight; y++)
            {
                for (int x = 0; x < location.map.Layers[0].LayerWidth; x++)
                {
                    this._map.Set(x, y, new Tile(x, y));
                }
            }

            this._loaded = true;
        }
    }
}

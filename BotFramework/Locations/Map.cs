using System.Collections.Generic;

namespace BotFramework.Locations
{
    /// <summary>
    /// Matrix of <see cref="Tile">Tiles</see> for a given <see cref="StardewValley.GameLocation">GameLocation</see>
    /// </summary>
    class Map
    {
        /// <summary>
        /// <see cref="StardewValley.GameLocation">GameLocation</see> name or unique name.
        /// </summary>
        private string _locationName;

        /// <summary>
        /// Matrix of <see cref="Tile">Tiles</see>
        /// </summary>
        private List<List<Tile>> _items;

        /// <summary>
        /// Whether or not the width's of each row are equal.
        /// </summary>
        private bool _jagged;

        /// <summary>
        /// Instantiates a Map
        /// </summary>
        /// <remarks>
        /// Matrix of <see cref="Tile">Tiles</see> for a given <see cref="StardewValley.GameLocation">GameLocation</see>
        /// </remarks>
        /// 
        /// <param name="name"><see cref="StardewValley.GameLocation">GameLocation</see> name or unique name</param>
        public Map(string name)
        {
            this._locationName = name;
            this._items = new List<List<Tile>>();
            this._jagged = true;
        }

        /// <summary>
        /// Retrieves <see cref="StardewValley.GameLocation">GameLocation</see> of Map's name
        /// </summary>
        /// 
        /// <returns>Unique name or name of <see cref="StardewValley.GameLocation">GameLocation</see></returns>
        public string GetName()
        {
            return this._locationName;
        }

        /// <summary>
        /// Retrieves <see cref="Tile">Tile</see> at a given X and Y coordinate.
        /// </summary>
        /// 
        /// <param name="x">X of <see cref="Tile">Tile</see> to retrieve</param>
        /// <param name="y">Y of <see cref="Tile">Tile</see> to retrieve</param>
        /// <returns><see cref="Tile">Tile</see> at given X and Y coordinates</returns>
        public Tile Get(int x, int y)
        {
            if (y < this._items.Count && x < this._items[y].Count)
            {
                return this._items[y][x];
            }
            return null;
        }

        /// <summary>
        /// Sets a <see cref="Tile">Tile</see> at a given X and Y coordinate.
        /// </summary>
        /// 
        /// <param name="x">X coordinate to place <see cref="Tile">Tile</see></param>
        /// <param name="y">Y coordinate to place <see cref="Tile">Tile</see></param>
        /// <param name="tile"><see cref="Tile">Tile</see> instance to set</param>
        public void Set(int x, int y, Tile tile)
        {
            this._jagged = true;
            if (y < this._items.Count && x < this._items[y].Count)
            {
                this._items[y][x] = tile;
            } 
            else
            {
                if (y >= this._items.Count)
                {
                    for (int i = 0; i < y - this._items.Count + 1; i++)
                    {
                        this._items.Add(new List<Tile>());
                    }
                }
                for (int i = 0; i < x - this._items[y].Count; i++)
                {
                    this._items[y].Add(null);
                }
                this._items[y].Add(tile);
            }
        }

        /// <summary>
        /// Retrieves width of map
        /// </summary>
        /// 
        /// <returns>Integer width of map</returns>
        public int GetWidth()
        {
            if (!this._jagged)
            {
                return this._items[0].Count;
            } else
            {
                int largest = -1;
                bool equal = true;

                foreach (List<Tile> row in this._items)
                {
                    if (largest == -1)
                    {
                        largest = row.Count;
                    } else if (row.Count > largest)
                    {
                        equal = false;
                        largest = row.Count;
                    }
                }

                if (equal)
                {
                    this._jagged = false;
                }

                return largest;
            }
        }

        /// <summary>
        /// Retrieves height of map
        /// </summary>
        /// 
        /// <returns>Integer height of map</returns>
        public int GetHeight()
        {
            return this._items.Count;
        }
    }
}

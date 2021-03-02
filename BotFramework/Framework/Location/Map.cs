using System.Collections.Generic;

namespace BotFramework.Framework.Location
{
    /// <summary>
    /// 2D Array of Tiles for a given GameLocation
    /// </summary>
    class Map
    {
        private string _name;
        private List<List<Tile>> _items;
        private bool _jagged;

        public Map(string name)
        {
            this._name = name;
            this._items = new List<List<Tile>>();
            this._jagged = true;
        }

        /// <summary>
        /// Retrieves GameLocation of Map's name
        /// </summary>
        /// 
        /// <returns>Unique name or name of GameLocation</returns>
        public string GetName()
        {
            return this._name;
        }

        /// <summary>
        /// Retrieves tile at a given X and Y coordinate.
        /// </summary>
        /// 
        /// <param name="x">X of tile to retrieve</param>
        /// <param name="y">Y of tile to retrieve</param>
        /// <returns>Tile at given X and Y coordinates</returns>
        public Tile Get(int x, int y)
        {
            if (y < this._items.Count && x < this._items[y].Count)
            {
                return this._items[y][x];
            }
            return null;
        }

        /// <summary>
        /// Sets a Tile at a given X and Y coordinate.
        /// </summary>
        /// 
        /// <param name="x">X coordinate to place tile</param>
        /// <param name="y">Y coordinate to place tile</param>
        /// <param name="tile">Tile instance to set</param>
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

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace BotFramework.Framework.Location
{
    /// <summary>
    /// References to a Tile in a GameLocation
    /// </summary>
    class Tile
    {
        private int _x;
        private int _y;
        private List<bool> _visited;

        public Tile(int x, int y)
        {
            this._x = x;
            this._y = y;

            this._visited = new List<bool>();
            this._visited.Add(false);
        }

        /// <summary>
        /// Retrieve X value of tile for that location.
        /// </summary>
        /// 
        /// <returns>X property of tile</returns>
        public int GetTileX()
        {
            return this._x;
        }

        /// <summary>
        /// Retrieve Y value of tile for that location.
        /// </summary>
        /// 
        /// <returns>Y property of tile</returns>
        public int GetTileY()
        {
            return this._y;
        }

        /// <summary>
        /// Retrieve whether tile has been visited.
        /// </summary>
        /// 
        /// <returns>Visited property of tile</returns>
        public bool GetVisited()
        {
            return this._visited[0];
        }

        /// <summary>
        /// Set whether tile has been visited.
        /// </summary>
        /// 
        /// <param name="value">Whether tile is visited</param>
        public void SetVisited(bool value)
        {
            this._visited[0] = value;
        }

        /// <summary>
        /// Retrieve whether tile has been visited at a certain index.
        /// </summary>
        /// 
        /// <param name="index">Index of visited property</param>
        /// <returns>Visited property of tile at a given index</returns>
        public bool GetVisited(int index)
        {
            return this._visited[index];
        }

        /// <summary>
        /// Set whether tile has been visited at a certain index.
        /// </summary>
        /// 
        /// <param name="index">Index of visited property</param>
        /// <param name="value">Whether tile is visited</param>
        public void SetVisited(int index, bool value)
        {
            // If visited does not contain index
            if (index >= this._visited.Count)
            {
                // Fill up to index
                for (int i = 0; i < index - this._visited.Count; i++)
                {
                    this._visited.Add(false);
                }
                // Add value
                this._visited.Add(value);
            } else
            {
                this._visited[index] = value;
            }
        }

        /// <summary>
        /// Manhattan distance to another point.
        /// </summary>
        /// 
        /// <param name="x">X value of other point</param>
        /// <param name="y">Y valie of other point</param>
        /// <returns>Integer distance between points</returns>
        public int DistanceTo(int x, int y)
        {
            return Math.Abs(x - this._x) + Math.Abs(y - this._y);
        }

        /// <summary>
        /// Manhattan distance to another Tile.
        /// </summary>
        /// 
        /// <param name="other">Other tile</param>
        /// <returns>Integer distance between points</returns>
        public int DistanceTo(Tile other)
        {
            return DistanceTo(other.GetTileX(), other.GetTileY());
        }

        /// <summary>
        /// Manhattan distance to another Point.
        /// </summary>
        /// 
        /// <param name="other">Other point</param>
        /// <returns>Integer distance between points</returns>
        public int DistanceTo(Point other)
        {
            return DistanceTo(other.X, other.Y);
        }

        /// <summary>
        /// Equality based on coordinates.
        /// </summary>
        /// 
        /// <param name="other">Other object</param>
        /// <returns>Whether other is a Tile and the same coordinates</returns>
        public override bool Equals(object obj)
        {
            return (obj is Tile &&
                ((Tile)obj).GetTileX() == this._x &&
                ((Tile)obj).GetTileY() == this._y);
        }

        /// <summary>
        /// Tile stringified to X and Y properties.
        /// </summary>
        public override string ToString()
        {
            return $"Tile - X: {this._x} Y: {this._y}";
        }
    }
}

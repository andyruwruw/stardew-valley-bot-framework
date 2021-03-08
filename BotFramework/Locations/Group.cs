using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework.Locations
{
    // <summary>
    /// List of spacially related Tiles
    /// </summary>
    class Group
    {
        private string _locationName;
        private List<Tile> _items;

        public Group()
        {
            this._items = new List<Tile>();
        }

        public Point GetCentroid()
        {
            int sumOfX = 0;
            int sumOfY = 0;

            foreach (Tile tile in this._items)
            {
                sumOfX += tile.GetTileX();
                sumOfY += tile.GetTileY();
            }

            return new Point((int)Math.Round((double)(sumOfX / this._items.Count)), (int)Math.Round((double)(sumOfY / this._items.Count)));
        }

        public Tile GetClosestTile(Point point)
        {
            Tile closest = null;
            int distance = int.MaxValue;

            foreach (Tile tile in this._items)
            {
                int currentDistance = tile.DistanceTo(point);
                if (closest == null || currentDistance < distance)
                {
                    closest = tile;
                    distance = currentDistance;
                }
            }

            return closest;
        }

        public void Add(Tile tile)
        {
            this._items.Add(tile);
        }

        public Tile Remove(Tile tile)
        {
            this._items.Remove(tile);
            return tile;
        }

        public Tile RemoveAt(int index)
        {
            Tile temp = this._items[index];
            this._items.RemoveAt(index);
            return temp;
        }
    }
}

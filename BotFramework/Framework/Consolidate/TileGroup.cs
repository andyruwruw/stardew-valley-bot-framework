using BotFramework.Framework.Location;
using System.Collections.Generic;

namespace BotFramework.Framework.Analysis
{
    /// <summary>
    /// List of spacially related Tiles
    /// </summary>
    class TileGroup
    {
        private List<Tile> _items;

        public TileGroup()
        {
            this._items = new List<Tile>();
        }
    }
}

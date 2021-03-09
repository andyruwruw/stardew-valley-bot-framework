using Microsoft.Xna.Framework;
using StardewValley.TerrainFeatures;

namespace BotFramework.Locations
{
    /// <summary>
    /// Interface for <see cref="Tile">Tile</see>
    /// </summary>
    /// <remarks>
    /// Represents a single tile in a <see cref="StardewValley.GameLocation">GameLocation</see>
    /// </remarks>
    interface ITile
    {
        /// <summary>
        /// Retrieve name of GameLocation this tile belongs to.
        /// </summary>
        /// 
        /// <returns>Name of GameLocation</returns>
        string GetLocationName();

        /// <summary>
        /// Retrieve X value of tile for that location.
        /// </summary>
        /// 
        /// <returns>X property of tile</returns>
        int GetTileX();

        /// <summary>
        /// Retrieve Y value of tile for that location.
        /// </summary>
        /// 
        /// <returns>Y property of tile</returns>
        int GetTileY();

        TerrainFeature GetTerrainFeature();

        /// <summary>
        /// Retrieve Point instance of Tile
        /// </summary>
        /// 
        /// <returns>Point instance</returns>
        Point GetPoint();

        /// <summary>
        /// Retrieve whether tile has been visited.
        /// </summary>
        /// 
        /// <returns>Visited property of tile</returns>
        bool GetVisited();

        /// <summary>
        /// Set whether tile has been visited.
        /// </summary>
        /// 
        /// <param name="value">Whether tile is visited</param>
        void SetVisited(bool value);

        /// <summary>
        /// Retrieve whether tile has been visited at a certain index.
        /// </summary>
        /// 
        /// <param name="index">Index of visited property</param>
        /// <returns>Visited property of tile at a given index</returns>
        bool GetVisited(int index);

        /// <summary>
        /// Set whether tile has been visited at a certain index.
        /// </summary>
        /// 
        /// <param name="index">Index of visited property</param>
        /// <param name="value">Whether tile is visited</param>
        void SetVisited(int index, bool value);

        /// <summary>
        /// Returns whether farmer can pass through tile.
        /// </summary>
        /// 
        /// <returns>Whether Tile is passable</returns>
        bool isPassable();

        /// <summary>
        /// Manhattan distance to another point.
        /// </summary>
        /// 
        /// <param name="x">X value of other point</param>
        /// <param name="y">Y valie of other point</param>
        /// <returns>Integer distance between points</returns>
        int DistanceTo(int x, int y);

        /// <summary>
        /// Manhattan distance to another Tile.
        /// </summary>
        /// 
        /// <param name="other">Other tile</param>
        /// <returns>Integer distance between points</returns>
        int DistanceTo(Tile other);

        /// <summary>
        /// Manhattan distance to another Point.
        /// </summary>
        /// 
        /// <param name="other">Other point</param>
        /// <returns>Integer distance between points</returns>
        int DistanceTo(Point other);
    }
}

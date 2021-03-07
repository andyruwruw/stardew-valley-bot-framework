namespace BotFramework.Locations
{
    /// <summary>
    /// Interface for <see cref="Map">Map</see>
    /// </summary>
    /// <remarks>
    /// Matrix of <see cref="Tile">Tiles</see> for a given <see cref="StardewValley.GameLocation">GameLocation</see>
    /// </remarks>
    interface IMap
    {
        /// <summary>
        /// Retrieves <see cref="StardewValley.GameLocation">GameLocation</see> of Map's name
        /// </summary>
        /// 
        /// <returns>Unique name or name of <see cref="StardewValley.GameLocation">GameLocation</see></returns>
        string GetName();

        /// <summary>
        /// Retrieves <see cref="Tile">Tile</see> at a given X and Y coordinate.
        /// </summary>
        /// 
        /// <param name="x">X of <see cref="Tile">Tile</see> to retrieve</param>
        /// <param name="y">Y of <see cref="Tile">Tile</see> to retrieve</param>
        /// <returns><see cref="Tile">Tile</see> at given X and Y coordinates</returns>
        Tile Get(int x, int y);

        /// <summary>
        /// Sets a <see cref="Tile">Tile</see> at a given X and Y coordinate.
        /// </summary>
        /// 
        /// <param name="x">X coordinate to place <see cref="Tile">Tile</see></param>
        /// <param name="y">Y coordinate to place <see cref="Tile">Tile</see></param>
        /// <param name="tile"><see cref="Tile">Tile</see> instance to set</param>
        void Set(int x, int y, Tile tile);

        /// <summary>
        /// Retrieves width of map
        /// </summary>
        /// 
        /// <returns>Integer width of map</returns>
        int GetWidth();

        /// <summary>
        /// Retrieves height of map
        /// </summary>
        /// 
        /// <returns>Integer height of map</returns>
        int GetHeight();
    }
}

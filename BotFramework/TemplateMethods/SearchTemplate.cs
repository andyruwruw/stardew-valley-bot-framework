using BotFramework.Locations;

namespace BotFramework.TemplateMethods
{
    /// <summary>
    /// Template method for finding closest <see cref="Locations.Tile">Tiles</see>.
    /// </summary>
    /// <remarks>
    /// Current breadth-first search implementation will be blocked by any unwalkable tiles.
    /// </remarks>
    class SearchTemplate
    {
        private IMap _map;

        public void Compute()
        {

        }
    }
}

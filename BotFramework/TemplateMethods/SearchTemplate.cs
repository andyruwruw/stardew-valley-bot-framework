using BotFramework.Locations;
using BotFramework.Targets;

namespace BotFramework.TemplateMethods
{
    /// <summary>
    /// Template method for finding closest <see cref="Locations.Tile">Tiles</see>.
    /// </summary>
    /// <remarks>
    /// Current breadth-first search implementation will be blocked by any unwalkable tiles.
    /// </remarks>
    class SearchTemplate<T>
    {
        private ITarget _target;

        private IMap _map;

        public SearchTemplate(ITarget target, IMap map)
        {
            this._target = target;
            this._map = map;
        }

        public void Compute()
        {

        }
    }
}

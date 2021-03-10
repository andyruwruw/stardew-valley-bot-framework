using BotFramework.Actions;
using BotFramework.Targets;
using StardewValley;
using System.Collections.Generic;

namespace BotFramework.Locations
{
    interface ILocationParser
    {
        /// <summary>
        /// Retrieve Map instance of location.
        /// </summary>
        /// 
        /// <returns>Map instance of location</returns>
        Map GetMap();

        List<Warp> GetWarps();

        string GetName();

        Queue<IAction> GetActions(IList<ITarget> targets);

        bool GetVisited();

        void SetVisited(bool visited);

        ITile WarpToTile(Warp warp);
    }
}

using BotFramework.Locations;
using BotFramework.Targets;
using StardewValley;
using System.Collections.Generic;

namespace BotFramework.Actions
{
    interface IAction
    {
        /// <summary>
        /// Retrieve <see cref="ActionType">ActionType</see> of Action.
        /// </summary>
        /// <returns><see cref="ActionType">ActionType</see></returns>
        ActionType GetActionType();

        /// <summary>
        /// Retrieves the <see cref="Target">Target</see> for a given item.
        /// </summary>
        /// <returns><see cref="Target">Target</see></returns>
        ITarget GetTarget();

        /// <summary>
        /// Retrieves where the bot should stand to execute actions.
        /// </summary>
        /// 
        /// <returns><see cref="Tile">Tile</see> of where bot should stand.</returns>
        ITile GetStand();

        /// <summary>
        /// Sets where the bot should stand to execute actions.
        /// </summary>
        void SetStand(ITile stand);
    }
}

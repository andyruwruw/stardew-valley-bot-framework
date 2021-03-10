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
        /// Retrieves the <see cref="Target">Target</see> for the action.
        /// </summary>
        /// <returns><see cref="Target">Target</see> of action</returns>
        ITarget GetTarget();

        /// <summary>
        /// Retrieves the <see cref="LocationParser">LocationParser</see> for the action.
        /// </summary>
        /// 
        /// <returns><see cref="LocationParser">LocationParser</see> of action</returns>
        ILocationParser GetLocationParser();
    }
}

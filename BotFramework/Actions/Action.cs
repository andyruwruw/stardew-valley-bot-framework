using BotFramework.Locations;
using BotFramework.Targets;
using StardewValley;
using System.Collections.Generic;

namespace BotFramework.Actions
{
    abstract class Action<T> : IAction
    {
        /// <summary>
        /// General behavior
        /// </summary>
        private ActionType _actionType;

        /// <summary>
        /// <see cref="Target">Target</see> used to find item.
        /// </summary>
        private ITarget _target;

        private ILocationParser _locationParser;

        public Action(ITarget target, ActionType actionType = ActionType.NavigateAndExecute, ILocationParser locationParser)
        {
            this._target = target;
            this._actionType = actionType;
            this._locationParser = locationParser;
        }

        /// <summary>
        /// Retrieve <see cref="ActionType">ActionType</see> of Action.
        /// </summary>
        /// <returns><see cref="ActionType">ActionType</see></returns>
        public ActionType GetActionType()
        {
            return this._actionType;
        }

        /// <summary>
        /// Retrieves the <see cref="Target">Target</see> for the action.
        /// </summary>
        /// <returns><see cref="Target">Target</see> of action</returns>
        public ITarget GetTarget()
        {
            return this._target;
        }

        /// <summary>
        /// Retrieves the <see cref="LocationParser">LocationParser</see> for the action.
        /// </summary>
        /// 
        /// <returns><see cref="LocationParser">LocationParser</see> of action</returns>
        public ILocationParser GetLocationParser()
        {
            return this._locationParser;
        }
    }
}

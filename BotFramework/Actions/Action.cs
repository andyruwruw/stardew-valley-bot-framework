using BotFramework.Locations;
using BotFramework.Targets;
using StardewValley;
using System.Collections.Generic;

namespace BotFramework.Actions
{
    abstract class Action<T> : IAction
    {
        /// <summary>
        /// <see cref="Target">Target</see> used to find item.
        /// </summary>
        private ITarget _target;

        /// <summary>
        /// Object the action is to be directed at.
        /// </summary>
        private T _directObject;

        /// <summary>
        /// <see cref="LocationParser">LocationParser</see> of action location.
        /// </summary>
        private ILocationParser _locationParser;

        /// <summary>
        /// General behavior
        /// </summary>
        private ActionType _actionType;

        public Action(ITarget target, T directObject, ILocationParser locationParser, ActionType actionType = ActionType.Execute)
        {
            this._target = target;
            this._directObject = directObject;
            this._locationParser = locationParser;
            this._actionType = actionType;
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
        /// Retreives the target item to be acted on.
        /// </summary>
        /// 
        /// <returns><see cref="Character">Character</see>, <see cref="StardewValley.Object">Object</see>, or <see cref="Tile">Tile</see></returns>
        public T GetDirectObject()
        {
            return this._directObject;
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

        /// <summary>
        /// Retrieve <see cref="ActionType">ActionType</see> of Action.
        /// </summary>
        /// <returns><see cref="ActionType">ActionType</see></returns>
        public ActionType GetActionType()
        {
            return this._actionType;
        }
    }
}

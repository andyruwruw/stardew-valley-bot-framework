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

        /// <summary>
        /// <see cref="Tile">Tile</see> of where to stand
        /// </summary>
        private ITile _stand;

        /// <summary>
        /// Where to execute actions
        /// </summary>
        private IList<T> _items;

        public Action(ITarget target, ActionType actionType = ActionType.NavigateAndExecute)
        {
            this._target = target;
            this._actionType = actionType;
            this._items = new List<T>();
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
        /// Retrieves the <see cref="Target">Target</see> for a given item.
        /// </summary>
        /// <returns><see cref="Target">Target</see></returns>
        public ITarget GetTarget()
        {
            return this._target;
        }

        /// <summary>
        /// Retrieves where the bot should stand to execute actions.
        /// </summary>
        /// 
        /// <returns><see cref="Tile">Tile</see> of where bot should stand.</returns>
        public ITile GetStand()
        {
            return this._stand;
        }

        /// <summary>
        /// Sets where the bot should stand to execute actions.
        /// </summary>
        public void SetStand(ITile stand)
        {
            this._stand = stand;
        }

        /// <summary>
        /// Retrieves on what targets the bot should execute actions.
        /// </summary>
        /// 
        /// <returns>List of items to execute actions on.</returns>
        public IList<T> GetItems()
        {
            return this._items;
        }

        /// <summary>
        /// Adds target the bot should execute actions.
        /// </summary>
        public void AddItem(T item)
        {
            this._items.Add(item);
        }

        public override string ToString()
        {
            string targetName = this._target == null ? "None" : this._target.GetName();
            LogProxy.Info($"targetname {targetName}");
            LogProxy.Info($"Tile exits {this._stand == null}");
            LogProxy.Info($"Tile x {this._stand.GetTileX()} {this._stand.GetTileY()}");
            return $"Action - Target: {targetName}, Stand: {this._stand.GetTileX()} {this._stand.GetTileY()}";
        }
    }
}

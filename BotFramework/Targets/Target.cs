using BotFramework.Characters;
using StardewValley;
using System.Collections.Generic;

namespace BotFramework.Targets
{
    /// <summary>
    /// Abstract class <c>Target</c> implements <see cref="ITarget">ITarget</see>.
    /// </summary>
    /// <remarks>
    /// <para>Specifies what items the bot should target, method by which targets are found, call order, post selectors and the action to be performed.</para>
    /// <para>See <see cref="TargetTile">TileTarget</see>, <see cref="TargetObject">ObjectTarget</see> and <see cref="TargetCharacter">CharacterTarget</see> for concrete classes.</para>
    /// </remarks>
    abstract class Target<T> : ITarget
    {
        protected static int numTargets = 0;

        /// <summary>
        /// Unique index of the target.
        /// </summary>
        private int _index;

        /// <summary>
        /// Unique name of the target.
        /// </summary>
        private string _name;

        /// <summary>
        /// Delegate for validating a target to be enqueued.
        /// </summary>
        private Validator<T> _validator;

        /// <summary>
        /// Whether to pursue target.
        /// </summary>
        private Condition<T> _condition;

        /// <summary>
        /// Delegate for the action to be performed on the target.
        /// </summary>
        private Action<T> _action;

        /// <summary>
        /// Pertaining to call order / condition check. This will impact when target is pulled out of the queue.
        /// </summary>
        private CallOrder _callOrder;

        /// <summary>
        /// Pertaining to the method targets are found and added to the queue.
        /// </summary>
        private QueryBehavior _query;

        /// <summary>
        /// Selectors applied after targets are found.
        /// </summary>
        private IList<PostQuerySelector> _selectors;

        /// <summary>
        /// Range by which target should perform action
        /// </summary>
        private int _actionableRange;

        /// <summary>
        /// Only applies to <see cref="QueryBehavior.DoForClosest">QueryBehavior.DoForClosest</see>. Used to extend functionality to: Do for closest {{doForClosestLimit}}
        /// </summary>
        private int _doForClosestLimit;

        /// <summary>
        /// Only applies to <see cref="QueryBehavior.WithinRange">QueryBehavior.WithinRange</see>. Clarifies what range to search for targets
        /// </summary>
        private int _withinRangeLimit;

        /// <summary>
        /// Instantiates a Target.
        /// </summary>
        /// <remarks>
        /// Used to specify the query method and selection of targets and the corresponding action to be performed.
        /// </remarks>
        /// 
        /// <param name="name">Unique name of the Target type</param>
        /// <param name="validator">Delegate method used to verify items fit this target's selection</param>
        /// <param name="condition">Delegate method used to confirm whether target should be found</param>
        /// <param name="action">Delegate method called when target is found and navigated to by the Bot</param>
        /// <param name="callOrder">Order by which the bot finds and focuses on targets. Within call order types, order by which the targets are passed into the Bot is upheld</param>
        /// <param name="query">Method by which targets should be found</param>
        /// <param name="selectors">Post query selectors. Used to select tiles spacially related to the target</param>
        /// <param name="actionableRange">Range by which target should perform action</param>
        /// <param name="doForClosestLimit">Only applies to <see cref="QueryBehavior.DoForClosest">QueryBehavior.DoForClosest</see>. Used to extend functionality to: Do for closest {{doForClosestLimit}}</param>
        /// <param name="withinRangeLimit">Only applies to <see cref="QueryBehavior.WithinRange">QueryBehavior.WithinRange</see>. Clarifies what range to search for targets</param>
        public Target(
            string name,
            Validator<T> validator,
            Condition<T> condition,
            Action<T> action,
            CallOrder callOrder = CallOrder.AtLocationStart,
            QueryBehavior query = QueryBehavior.DoForAll,
            IList<PostQuerySelector> selectors = null,
            int actionableRange = 1,
            int doForClosestLimit = 1,
            int withinRangeLimit = 1
        )
        {
            this._index = numTargets;
            numTargets = numTargets + 1;

            this._name = name;
            this._validator = validator;
            this._condition = condition;
            this._action = action;
            this._callOrder = callOrder;
            this._query = query;
            this._selectors = selectors;
            this._actionableRange = actionableRange;
            this._doForClosestLimit = doForClosestLimit;
            this._withinRangeLimit = withinRangeLimit;

            if (this._selectors == null)
            {
                this._selectors = new List<PostQuerySelector>();
                this._selectors.Add(PostQuerySelector.TileOf);
            }
        }

        /// <summary>
        /// Retrieves name of target type.
        /// </summary>
        /// 
        /// <returns>Name of target type</returns>
        public string GetName()
        {
            return this._name;
        }

        /// <summary>
        /// Retrieves <see cref="CallOrder">CallOrder</see> of target type.
        /// </summary>
        /// 
        /// <returns><see cref="CallOrder">CallOrder</see> enum value</returns>
        public CallOrder GetCallOrder()
        {
            return this._callOrder;
        }

        /// <summary>
        /// Retrieves <see cref="QueryBehavior">QueryBehavior</see> of target type.
        /// </summary>
        /// 
        /// <returns><see cref="QueryBehavior">QueryBehavior</see> enum value</returns>
        public QueryBehavior GetQueryBehavior()
        {
            return this._query;
        }

        /// <summary>
        /// Retrieves <see cref="PostQuerySelector">PostQuerySelector</see> of target type.
        /// </summary>
        /// 
        /// <returns><see cref="PostQuerySelector">PostQuerySelector</see> enum value</returns>
        public IList<PostQuerySelector> GetPostQuerySelectors()
        {
            return this._selectors;
        }

        /// <summary>
        /// Retrieves actionable range of target type.
        /// </summary>
        /// 
        /// <returns>Integer range</returns>
        public int GetActionableRange()
        {
            return this._actionableRange;
        }

        /// <summary>
        /// Retrieves <see cref="QueryBehavior.DoForClosest">QueryBehavior.DoForClosest</see> limit of target type.
        /// </summary>
        /// 
        /// <returns>Integer limit</returns>
        public int GetDoForClosestLimit()
        {
            return this._doForClosestLimit;
        }

        /// <summary>
        /// Retrieves range of target type.
        /// </summary>
        /// 
        /// <returns>Integer limit</returns>
        public int GetWithinRangeLimit()
        {
            return this._withinRangeLimit;
        }

        /// <summary>
        /// Validates targets to be enqueued.
        /// </summary>
        /// 
        /// <param name="item">Possible target (<see cref="Locations.Tile">Tile</see>, <see cref="StardewValley.Character">Character</see>, <see cref="StardewValley.Object">Object</see>)</param>
        /// <returns>Whether item is valid target</returns>
        public bool IsTarget(T item)
        {
            return this._validator(item);
        }

        /// <summary>
        /// Envokes action on target upon getting within range.
        /// </summary>
        /// 
        /// <param name="who"><see cref="Character">Character</see> instance of <see cref="Bot">Bot</see></param>
        /// <param name="where">Current <see cref="GameLocation">GameLocation</see></param>
        /// <param name="what">Target (<see cref="Locations.Tile">Tile</see>, <see cref="StardewValley.Character">Character</see>, <see cref="StardewValley.Object">Object</see>)</param>
        public void PerformAction(Character who, GameLocation where, T what)
        {
            this._action(who, where, what);
        }
    }
}

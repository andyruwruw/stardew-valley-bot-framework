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
    abstract class Target : ITarget
    {
        private string _name;
        private Validator _validator;
        private Action _action;
        private CallOrder _callOrder;
        private QueryBehavior _query;
        private IList<PostQuerySelector> _selectors;
        private int _actionableRange;
        private int _doForClosestLimit;
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
        /// <param name="action">Delegate method called when target is found and navigated to by the Bot</param>
        /// <param name="callOrder">Order by which the bot finds and focuses on targets. Within call order types, order by which the targets are passed into the Bot is upheld</param>
        /// <param name="query">Method by which targets should be found</param>
        /// <param name="selectors">Post query selectors. Used to select tiles spacially related to the target</param>
        /// <param name="actionableRange">Range by which target should perform action</param>
        /// <param name="doForClosestLimit">Only applies to QueryBehavior.DoForClosest. Used to extend functionality to: Do for closest {{doForClosestLimit}}</param>
        /// <param name="withinRangeLimit">Only applies to QueryBehavior.WithinRange. Clarifies what range to search for targets</param>
        public Target(
            string name,
            Validator validator,
            Action action,
            CallOrder callOrder = CallOrder.AtLocationStart,
            QueryBehavior query = QueryBehavior.DoForAll,
            IList<PostQuerySelector> selectors = null,
            int actionableRange = 1,
            int doForClosestLimit = 1,
            int withinRangeLimit = 1
        )
        {
            this._name = name;
            this._validator = validator;
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
        /// Retrieves CallOrder of target type.
        /// </summary>
        /// 
        /// <returns>CallOrder enum value</returns>
        public CallOrder GetCallOrder()
        {
            return this._callOrder;
        }

        /// <summary>
        /// Retrieves QueryBehavior of target type.
        /// </summary>
        /// 
        /// <returns>QueryBehavior enum value</returns>
        public QueryBehavior GetQueryBehavior()
        {
            return this._query;
        }

        /// <summary>
        /// Retrieves PostQuerySelector of target type.
        /// </summary>
        /// 
        /// <returns>PostQuerySelector enum value</returns>
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
        /// Retrieves QueryBehavior.DoForClosest limit of target type.
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
        /// <param name="item">Possible target (Tile, Character, Object)</param>
        /// <returns>Whether item is valid target</returns>
        public bool IsTarget(dynamic item)
        {
            return this._validator(item);
        }

        /// <summary>
        /// Envokes action on target upon getting within range.
        /// </summary>
        /// 
        /// <param name="who">Character instance of Bot</param>
        /// <param name="where">Current GameLocation</param>
        /// <param name="what">Target (Tile, Character, Object)</param>
        public void PerformAction(Character who, GameLocation where, dynamic what)
        {
            this._action(who, where, what);
        }
    }
}

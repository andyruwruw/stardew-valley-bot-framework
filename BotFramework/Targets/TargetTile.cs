using BotFramework.Locations;
using System.Collections.Generic;

namespace BotFramework.Targets
{
    /// <summary>
    /// Tile specific Target.
    /// Specifies what Tiles the bot should target, method by which tiles are found, call order, post selectors and the action to be performed.
    /// </summary>
    class TargetTile : Target<Tile>
    {
        /// <summary>
        /// Instantiates a TileTarget, used to specify the query method and selection of tiles and the corresponding action to be performed.
        /// </summary>
        /// 
        /// <param name="name">Unique name of the Target type</param>
        /// <param name="validator">Delegate method used to verify items fit this target's selection</param>
        /// <param name="action">Delegate method called when target is found and navigated to by the Bot</param>
        /// <param name="callOrder">Order by which the bot finds and focuses on targets. Within call order types, order by which the targets are passed into the Bot is upheld.</param>
        /// <param name="query">Method by which targets should be found.</param>
        /// <param name="selectors"></param>
        public TargetTile(
            string name,
            Validator<Tile> validator,
            Condition<Tile> condition,
            Action<Tile> action,
            CallOrder callOrder = CallOrder.AtLocationStart,
            QueryBehavior query = QueryBehavior.DoForAll,
            IList<PostQuerySelector> selectors = null,
            int actionableRange = 1,
            int doForClosestLimit = 1,
            int withinRangeLimit = 1
        ) : base(
            name,
            validator,
            condition,
            action,
            callOrder,
            query,
            selectors,
            actionableRange,
            doForClosestLimit,
            withinRangeLimit
        )
        { }
    }
}

using System.Collections.Generic;

namespace BotFramework.Targets
{
    /// <summary>
    /// StardewValley.Object specific Target.
    /// Specifies what Objects the bot should target, method by which objects are found, call order, post selectors and the action to be performed.
    /// </summary>
    class TargetObject : Target<StardewValley.Object>
    {
        /// <summary>
        /// Instantiates an ObjectTarget, used to specify the query method and selection of objects and the corresponding action to be performed.
        /// </summary>
        /// 
        /// <param name="name">Unique name of the Target type</param>
        /// <param name="validator">Delegate method used to verify items fit this target's selection</param>
        /// <param name="action">Delegate method called when target is found and navigated to by the Bot</param>
        /// <param name="callOrder">Order by which the bot finds and focuses on targets. Within call order types, order by which the targets are passed into the Bot is upheld.</param>
        /// <param name="query">Method by which targets should be found.</param>
        /// <param name="selectors"></param>
        public TargetObject(
            string name,
            Validator<StardewValley.Object> validator,
            Action<StardewValley.Object> action,
            CallOrder callOrder = CallOrder.AtLocationStart,
            QueryBehavior query = QueryBehavior.DoForAll,
            IList<PostQuerySelector> selectors = null,
            int actionableRange = 1,
            int doForClosestLimit = 1,
            int withinRangeLimit = 1
        ) : base(
            name,
            validator,
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

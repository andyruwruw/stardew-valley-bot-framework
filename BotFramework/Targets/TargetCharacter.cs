using StardewValley;
using System.Collections.Generic;

namespace BotFramework.Targets
{
    /// <summary>
    /// Character specific Target.
    /// Specifies what Character the bot should target, method by which characters are found, call order, post selectors and the action to be performed.
    /// </summary>
    class TargetCharacter : Target<Character>
    {
        /// <summary>
        /// Instantiates a CharacterTarget, used to specify the query method and selection of characters and the corresponding action to be performed.
        /// </summary>
        /// 
        /// <param name="name">Unique name of the Target type</param>
        /// <param name="validator">Delegate method used to verify items fit this target's selection</param>
        /// <param name="action">Delegate method called when target is found and navigated to by the Bot</param>
        /// <param name="callOrder">Order by which the bot finds and focuses on targets. Within call order types, order by which the targets are passed into the Bot is upheld.</param>
        /// <param name="query">Method by which targets should be found.</param>
        /// <param name="selectors"></param>
        public TargetCharacter(
            string name,
            Validator<Character> validator,
            Condition<Character> condition,
            Action<Character> action,
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

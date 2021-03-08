using System;

namespace BotFramework.Targets
{
    class TargetAction : Target<Object>
    {
        public TargetAction(
            string name,
            Condition<Object> condition,
            Action<Object> action
        ) : base(
            name,
            validator: null,
            condition,
            action,
            callOrder: CallOrder.AtLocationStart,
            query: QueryBehavior.DoForAll,
            selectors: null,
            actionableRange: 0,
            doForClosestLimit: 1,
            withinRangeLimit: 1
        )
        { }
    }
}

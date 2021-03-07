namespace BotFramework.Targets
{
    class TargetAction : Target
    {
        public TargetAction(
            string name,
            Action action
        ) : base(
            name,
            validator: null,
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

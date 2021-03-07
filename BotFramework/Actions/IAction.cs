using BotFramework.Targets;

namespace BotFramework.Actions
{
    enum ActionType
    {
        Navigate,
        NavigateAndExecute,
        Execute,
    }

    interface IAction
    {
        ITarget GetTarget();

        ActionType GetActionType();
    }
}

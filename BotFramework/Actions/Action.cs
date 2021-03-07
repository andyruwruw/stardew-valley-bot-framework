using BotFramework.Targets;

namespace BotFramework.Actions
{
    abstract class Action : IAction
    {
        private ActionType _type;
        private ITarget _target;

        public ITarget GetTarget()
        {
            return this._target;
        }

        public ActionType GetActionType()
        {
            return this._type;
        }
    }
}

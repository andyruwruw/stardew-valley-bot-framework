using StardewValley;

namespace BotFramework.Framework.Targets
{
    class Target
    {
        public delegate bool Validator (dynamic item);
        public delegate void Action(Character who, GameLocation where, dynamic what);

        private string _name = "Target";

        public Target(string name, Validator validator, Action action)
        {
            this._name = name;
            this.IsTarget = validator;
            this.PerformAction = action;
        }

        public Validator IsTarget;

        public Action PerformAction;

        public string GetName()
        {
            return this._name;
        }
    }
}

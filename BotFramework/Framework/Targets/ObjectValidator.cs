namespace BotFramework.Framework.Targets
{
    class ObjectTarget : Target
    {
        public ObjectTarget(string name, Validator validator, Action action) : base(name, validator, action) { }
    }
}

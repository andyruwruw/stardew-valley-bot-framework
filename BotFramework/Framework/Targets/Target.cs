namespace BotFramework.Targets
{
    class Target : ITarget
	{
		private TargetType _type;

		public Target(TargetType type)
		{
			this._type = type;
		}

		public TargetType GetType()
		{
			return this._type;
		}
	}
}

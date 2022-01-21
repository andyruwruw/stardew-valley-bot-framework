using BotFramework.Framework.Stimulus;

namespace BotFramework.Framework.Behaviors
{
    class Behavior : IBehavior
	{
		private BehaviorType _type;

		private IStimulus _stimulus;

		public Behavior(BehaviorType type, IStimulus stimulus)
		{
			this._type = type;
			this._stimulus = stimulus;
		}

		public BehaviorType GetType()
		{
			return this._type;
		}

		public IStimulus GetStimulus()
		{
			return this._stimulus;
		}
	}
}

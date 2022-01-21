namespace BotFramework.Framework.Stimulus
{
    class Stimulus : IStimulus
	{
		private StimulusType _type;

		public Stimulus(StimulusType type)
		{
			this._type = type;
		}

		public StimulusType GetType()
		{
			return this._type;
		}
	}
}

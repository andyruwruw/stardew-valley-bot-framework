using BotFramework.Framework.Behaviors;
using StardewValley;

namespace BotFramework
{
    class Bot : IBot
	{
		private Character _character;

		private Behavior[] _behaviors;

		public Bot(Character character, Behavior[] behaviors)
		{
			this._character = character;
			this._behaviors = behaviors;
		}

		public Character GetCharacter()
		{
			return this._character;
		}

		public void SetBehaviors(Behavior[] behaviors)
		{
			this._behaviors = behaviors;
		}

		public Behavior[] GetBehaviors()
		{
			return this._behaviors;
		}
	}
}

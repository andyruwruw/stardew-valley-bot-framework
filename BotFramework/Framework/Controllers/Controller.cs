using BotFramework.Procedures;
using StardewValley;

namespace BotFramework.Controllers
{
    class Controller : IController
	{
		protected Character _character;

		protected IProcedure _procedure;

		public Controller(Character character)
		{
			_character = character;
		}

		public void Update()
		{

		}

		public Character GetCharacter()
		{
			return _character;
		}

		public IProcedure GetProcedure()
		{
			return _procedure;
		}

		public void SetProcedure(IProcedure procedure)
		{
			_procedure = procedure;
		}
	}
}

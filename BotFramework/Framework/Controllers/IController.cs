using BotFramework.Procedures;
using StardewValley;

namespace BotFramework.Controllers
{
    interface IController
	{
		void Update();

		Character GetCharacter();

		IProcedure GetProcedure();

		void SetProcedure(IProcedure procedure);
	}
}

using BotFramework.Procedures;

namespace BotFramework.Controllers
{
    class Controller : IController
    {
        private Procedure _procedure;

        public void UpdateProcedure(Procedure procedure)
        {
            this._procedure = procedure;
        }
    }
}

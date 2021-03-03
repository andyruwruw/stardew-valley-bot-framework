using StardewValley;

namespace BotFramework.Framework.Controller
{
    /// <summary>
    /// Handles character navigation and actions.
    /// </summary>
    class CharacterController
    {
        private Character _who;

        public CharacterController(Character who) {
            this._who = who;
        }
    }
}

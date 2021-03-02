using StardewValley;

namespace BotFramework.Framework.PlayerControler
{
    /// <summary>
    /// Handles character navigation and actions.
    /// </summary>
    class PlayerController
    {
        private Character _who;

        public PlayerController(Character who) {
            this._who = who;
        }
    }
}

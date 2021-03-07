using StardewValley;

namespace BotFramework.Characters
{
    /// <summary>
    /// Handles character navigation and actions.
    /// </summary>
    class CharacterController : ICharacterController
    {
        private Character _who;

        public CharacterController(Character who) {
            this._who = who;
        }
    }
}

using StardewValley;

namespace BotFramework.Characters {
    interface ICharacterController
    {
        Character GetCharacter();

        GameLocation GetCurrentLocation();
    }
}

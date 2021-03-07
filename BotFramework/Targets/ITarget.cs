using BotFramework.Characters;
using BotFramework.Locations;
using StardewValley;

namespace BotFramework.Targets
{
    /// <summary>
    /// Validates <see cref="Target">Targets</see> to be enqueued.
    /// </summary>
    /// <remarks>
    /// <para>Delegate method returning <c>true</c> or <c>false</c>.</para>
    /// <para>Relevant context will be provided in parameters.</para>
    /// </remarks>
    /// 
    /// <param name="item">Possible <see cref="Target">Target</see> (<see cref="Locations.Tile">Tile</see>, <see cref="StardewValley.Character">Character</see>, <see cref="StardewValley.Object">Object</see>)</param>
    /// <returns>Whether item is valid <see cref="Target">Target</see></returns>
    delegate bool Validator<T>(T item);

    delegate bool Condition<T>(ICharacterController who, GameLocation where, T what);

    /// <summary>
    /// Action to envoke on <see cref="Target">Target</see> upon getting within range.
    /// </summary>
    /// 
    /// <param name="who"><see cref="Character">Character</see> instance of <see cref="Bot">Bot</see></param>
    /// <param name="where">Current <see cref="GameLocation">GameLocation</see></param>
    /// <param name="what"><see cref="Target">Target</see> object (<see cref="Locations.Tile">Tile</see>, <see cref="StardewValley.Character">Character</see>, <see cref="StardewValley.Object">Object</see>)</param>
    delegate void Action<T>(Character who, GameLocation where, T what);

    /// <summary>
    /// Interface for all Target types. 
    /// </summary>
    /// <remarks>
    /// Specifies what items the bot should target, method by which targets are found, call order, post selectors and the action to be performed.
    /// </remarks>
    interface ITarget<T>
    {
        /// <summary>
        /// Retrieves name of target type.
        /// </summary>
        /// 
        /// <returns>Name of target type</returns>
        string GetName();

        /// <summary>
        /// Retrieves CallOrder of target type.
        /// </summary>
        /// 
        /// <returns>CallOrder enum value</returns>
        CallOrder GetCallOrder();

        /// <summary>
        /// Retrieves QueryBehavior of target type.
        /// </summary>
        /// 
        /// <returns>QueryBehavior enum value</returns>
        QueryBehavior GetQueryBehavior();

        /// <summary>
        /// Validates targets to be enqueued.
        /// </summary>
        /// 
        /// <param name="item">Possible target (<see cref="Locations.Tile">Tile</see>, <see cref="StardewValley.Character">Character</see>, <see cref="StardewValley.Object">Object</see>)</param>
        /// <returns>Whether item is valid target</returns>
        bool IsTarget(T item);

        /// <summary>
        /// Envokes action on target upon getting within range.
        /// </summary>
        /// 
        /// <param name="who"><see cref="Character">Character</see> instance of <see cref="Bot">Bot</see></param>
        /// <param name="where">Current <see cref="GameLocation">GameLocation</see></param>
        /// <param name="what">Target (<see cref="Locations.Tile">Tile</see>, <see cref="StardewValley.Character">Character</see>, <see cref="StardewValley.Object">Object</see>)</param>
        void PerformAction(Character who, GameLocation where, T what);
    }
}

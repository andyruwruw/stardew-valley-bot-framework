using BotFramework.Characters;
using StardewValley;

namespace BotFramework.Targets
{
    /// <summary>
    /// Validates <see cref="ITarget">Targets</see> to be enqueued.
    /// </summary>
    /// <remarks>
    /// <para>Delegate method returning <c>true</c> or <c>false</c>.</para>
    /// <para>Relevant context will be provided in parameters.</para>
    /// </remarks>
    /// 
    /// <param name="item">Possible target (Tile, Character, Object)</param>
    /// <returns>Whether item is valid target</returns>
    delegate bool Validator(dynamic item);

    delegate bool Condition(ICharacterController who, GameLocation where, dynamic what);

    /// <summary>
    /// Action to envoke on target upon getting within range.
    /// </summary>
    /// 
    /// <param name="who">Character instance of Bot</param>
    /// <param name="where">Current GameLocation</param>
    /// <param name="what">Target (Tile, Character, Object)</param>
    delegate void Action(Character who, GameLocation where, dynamic what);

    /// <summary>
    /// Interface for all Target types. 
    /// Specifies what items the bot should target, method by which targets are found, call order, post selectors and the action to be performed.
    /// </summary>
    interface ITarget
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
        /// <param name="item">Possible target (Tile, Character, Object)</param>
        /// <returns>Whether item is valid target</returns>
        bool IsTarget(dynamic item);

        /// <summary>
        /// Envokes action on target upon getting within range.
        /// </summary>
        /// 
        /// <param name="who">Character instance of Bot</param>
        /// <param name="where">Current GameLocation</param>
        /// <param name="what">Target (Tile, Character, Object)</param>
        void PerformAction(Character who, GameLocation where, dynamic what);
    }
}

using BotFramework.Actions;
using BotFramework.Targets;
using StardewValley;
using System.Collections.Generic;

namespace BotFramework.World
{
    interface IWorldParser
    {
        /// <summary>
        /// Sets locations by single GameLocation instance.
        /// </summary>
        /// 
        /// <param name="location">GameLocation instance</param>
        void SetLocation(GameLocation location);

        /// <summary>
        /// Sets locations by single location names or unique names.
        /// </summary>
        /// 
        /// <param name="location">Location names or unique name</param>
        void SetLocation(string locationName);

        /// <summary>
        /// Sets locations by GameLocation instances.
        /// </summary>
        /// 
        /// <param name="location">List of GameLocation</param>
        void SetLocations(IList<GameLocation> locations);

        /// <summary>
        /// Sets locations by location names or unique names.
        /// </summary>
        /// 
        /// <param name="location">List of location names or unique names</param>
        void SetLocations(IList<string> locations);

        /// <summary>
        /// Finds shortest path through all provided GameLocations
        /// </summary>
        void GenerateActionableLocations();

        /// <summary>
        /// Returns actions based on targets for current location.
        /// </summary>
        /// 
        /// <param name="targets">List of applicable targets for query.</param>
        /// <returns>List of actions</returns>
        Queue<IAction> GetActions(IList<ITarget> targets);
    }
}

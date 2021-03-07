using BotFramework.Targets;
using StardewValley;
using System.Collections.Generic;

namespace BotFramework
{
    /// <summary>
    /// Interface class for <see cref="Bot">Bot</see>
    /// </summary>
    /// <remarks>
    /// It is recommended you instantiate with <see cref="Bot">Bot</see>, but use IBot for variable types.
    /// </remarks>
    interface IBot
    {
        void DefaultTargets();

        void SetTarget(ITarget target);

        void SetTargets(IList<ITarget> targets);

        void DefaultLocations();

        void SetLocation(GameLocation location);

        void SetLocation(string locationName);

        /// <summary>
        /// Sets list of locations by GameLocation objects.
        /// </summary>
        /// 
        /// <param name="locations">List of GameLocation instances</param>
        void SetLocations(IList<GameLocation> locations);

        /// <summary>
        /// Sets list of locations by location names or unique names.
        /// </summary>
        /// 
        /// <param name="locations">List of GameLocation instances</param>
        void SetLocations(IList<string> locationNames);

        /// <summary>
        /// Begins the bot process (trigger).
        /// </summary>
        void Start();
    }
}

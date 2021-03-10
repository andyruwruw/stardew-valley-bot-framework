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
        /// <summary>
        /// Manual way of setting <see cref="BotFramework.Targets.Target{T}">Target</see> values.
        /// </summary>
        /// <remarks>
        /// If your Bot's behavior is static, override <see cref="DefaultTargets">Bot.DefaultTargets</see> instead.
        /// </remarks>
        /// 
        /// <param name="target">List of <see cref="BotFramework.Targets.Target{T}">Targets</see> to give the Bot purpose</param>
        void SetTargets(IList<ITarget> targets);

        /// <summary>
        /// Manual way of setting <see cref="BotFramework.Targets.Target{T}">Target</see> values.
        /// </summary>
        /// <remarks>
        /// If your Bot's behavior is static, override <see cref="DefaultTargets">Bot.DefaultTargets</see> instead.
        /// </remarks>
        /// 
        /// <param name="target">List of <see cref="BotFramework.Targets.Target{T}">Targets</see> to give the Bot purpose</param>
        void SetTargets(ITarget target);

        /// <summary>
        /// Manual way of setting <see cref="GameLocation">GameLocation</see> values.
        /// </summary>
        /// <remarks>
        /// If your Bot's behavior is static, override <see cref="DefaultLocations">Bot.DefaultLocations</see> instead.
        /// </remarks>
        /// 
        /// <param name="target">List of <see cref="GameLocation">GameLocations</see> to tell the Bot where you want it to work</param>
        void SetLocations(IList<GameLocation> locations);

        /// <summary>
        /// Manual way of setting <see cref="GameLocation">GameLocation</see> values.
        /// </summary>
        /// <remarks>
        /// If your Bot's behavior is static, override <see cref="DefaultLocations">Bot.DefaultLocations</see> instead.
        /// </remarks>
        /// 
        /// <param name="target">List of <see cref="GameLocation">GameLocations</see> to tell the Bot where you want it to work</param>
        void SetLocations(IList<string> locationNames);

        /// <summary>
        /// Manual way of setting <see cref="GameLocation">GameLocation</see> values.
        /// </summary>
        /// <remarks>
        /// If your Bot's behavior is static, override <see cref="DefaultLocations">Bot.DefaultLocations</see> instead.
        /// </remarks>
        /// 
        /// <param name="target">List of <see cref="GameLocation">GameLocations</see> to tell the Bot where you want it to work</param>
        void SetLocations(GameLocation location);

        /// <summary>
        /// Manual way of setting <see cref="GameLocation">GameLocation</see> values.
        /// </summary>
        /// <remarks>
        /// If your Bot's behavior is static, override <see cref="DefaultLocations">Bot.DefaultLocations</see> instead.
        /// </remarks>
        /// 
        /// <param name="target">List of <see cref="GameLocation">GameLocations</see> to tell the Bot where you want it to work</param>
        void SetLocations(string locationName);

        /// <summary>
        /// Begins the Bot process (trigger).
        /// </summary>
        void Start();
    }
}

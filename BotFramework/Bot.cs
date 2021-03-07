using BotFramework.Helpers;
using BotFramework.Targets;
using StardewValley;
using System;
using System.Collections.Generic;

namespace BotFramework
{
    /// <summary>
    /// Bot class provides template method for developers to configure the framework.
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    abstract class Bot : IBot
    {
        /// <summary>
        /// Whether or not the bot is running.
        /// </summary>
        private bool _active = false;

        /// <summary>
        /// Target management class.
        /// </summary>
        private IBrain _brain;

        /// <summary>
        /// Instantiates a Bot.
        /// </summary>
        /// <remarks>
        /// <para><see href="https://www.youtube.com/watch?v=Yw6u6YkTgQ4">Your bot wakes up confused and lost.</see></para>
        /// <para>Be a friend, treat him well.</para>
        /// <para>Give him some <see cref="ITarget">Targets</see> for some purpose in life.</para>
        /// </remarks>
        ///
        /// <param name="character"></param>
        public Bot() : this(Game1.player) { }

        /// <summary>
        /// Instantiates a Bot.
        /// </summary>
        /// <remarks>
        /// <para><see href="https://www.youtube.com/watch?v=Yw6u6YkTgQ4">Your bot wakes up confused and lost.</see></para>
        /// <para>Be a friend, treat him well.</para>
        /// <para>Give him some <see cref="ITarget">Targets</see> for some purpose in life.</para>
        /// </remarks>
        ///
        /// <param name="character"></param>
        public Bot(Character character)
        {
            // Wake up friend
            this._brain = new Brain();
        }

        public void DefaultTargets()
        {
            List<ITarget> targets = new List<ITarget>();
            this._brain.SetTargets(targets);
        }

        public void SetTarget(ITarget target)
        {
            List<ITarget> targets = new List<ITarget>();
            targets.Add(target);

            this.SetTargets(targets);
        }

        public void SetTargets(IList<ITarget> targets)
        {
            if (targets.Count == 0)
            {
                throw new ArgumentException("Targets cannot be empty.");
            }
            this._brain.SetTargets(targets);
        }

        public void DefaultLocations()
        {
            List<GameLocation> locations = new List<GameLocation>();
            locations.Add(Game1.currentLocation);
            this._brain.SetLocations(locations);
        }

        public void SetLocation(GameLocation location)
        {
            this._brain.SetLocation(location);
        }

        public void SetLocation(string locationName)
        {
            this._brain.SetLocation(locationName);
        }

        /// <summary>
        /// Sets list of locations by GameLocation objects.
        /// </summary>
        /// 
        /// <param name="locations">List of GameLocation instances</param>
        public void SetLocations(IList<GameLocation> locations)
        {
            this._brain.SetLocations(locations);
        }

        /// <summary>
        /// Sets list of locations by location names or unique names.
        /// </summary>
        /// 
        /// <param name="locations">List of GameLocation instances</param>
        public void SetLocations(IList<string> locationNames)
        {
            this._brain.SetLocations(locationNames);
        }

        /// <summary>
        /// Begins the bot process (trigger).
        /// </summary>
        public void Start()
        {
            LogProxy.Log("Bot has begun work");
            this.StartCallback();
            this._active = true;

            this._brain.Start();
        }

        /// <summary>
        /// Run at the start of the process, optional override
        /// </summary>
        protected void StartCallback()
        {
            LogProxy.Log("Bot.StartCallback called with no override", true);
        }

        /// <summary>
        /// Run at the end of the process, optional override
        /// </summary>
        protected void InterruptedCallback()
        {
            LogProxy.Log("Bot.InterruptedCallback called with no override", true);
        }

        /// <summary>
        /// Run at the end of the process, optional override
        /// </summary>
        protected void FinishCallback()
        {
            LogProxy.Log("Bot.FinishCallback called with no override", true);
        }
    }
}

using BotFramework.Actions;
using BotFramework.Characters;
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
        /// Whether the bot is running.
        /// </summary>
        private bool _active = false;

        /// <summary>
        /// Whether <see cref="GameLocation">Location</see> data has been set.
        /// </summary>
        private bool _locationsSet = false;

        /// <summary>
        /// Whether <see cref="BotFramework.Targets.Target{T}">Target</see> data has been set.
        /// </summary>
        private bool _targetsSet = false;

        /// <summary>
        /// <see cref="BotFramework.Targets.Target{T}">Target</see> management class.
        /// </summary>
        private IBrain _brain;

        /// <summary>
        /// <see cref="Character">Character</see> controller, facade for Character class.
        /// </summary>
        private ICharacterController _character;

        /// <summary>
        /// Instantiates a Bot.
        /// </summary>
        /// <remarks>
        /// <para>Your bot wakes up <see href="https://www.youtube.com/watch?v=Yw6u6YkTgQ4">confused and lost.</see> Be a friend, treat him well.</para>
        /// <para>Give him some <see cref="ITarget">Targets</see> for some purpose in life.</para>
        /// </remarks>
        ///
        /// <param name="character"><see cref="Character">Character</see> the bot controls</param>
        public Bot() : this(Game1.player) { }

        /// <summary>
        /// Instantiates a Bot.
        /// </summary>
        /// <remarks>
        /// <para>Your bot wakes up <see href="https://www.youtube.com/watch?v=Yw6u6YkTgQ4">confused and lost.</see> Be a friend, treat him well.</para>
        /// <para>Give him some <see cref="ITarget">Targets</see> for some purpose in life.</para>
        /// </remarks>
        ///
        /// <param name="character"><see cref="Character">Character</see> the bot controls</param>
        public Bot(Character character)
        {
            // Wake up friend
            this._brain = new Brain();
            this._character = new CharacterController(character);
        }

        /// <summary>
        /// Manual way of setting <see cref="BotFramework.Targets.Target{T}">Target</see> values.
        /// </summary>
        /// <remarks>
        /// If your Bot's behavior is static, override <see cref="DefaultTargets">Bot.DefaultTargets</see> instead.
        /// </remarks>
        /// 
        /// <param name="target">List of <see cref="BotFramework.Targets.Target{T}">Targets</see> to give the Bot purpose</param>
        public void SetTargets(IList<ITarget> targets)
        {
            if (targets.Count == 0)
            {
                throw new ArgumentException("Targets cannot be empty.");
            }
            this._brain.SetTargets(targets);
            this._targetsSet = true;
        }

        /// <summary>
        /// Manual way of setting <see cref="BotFramework.Targets.Target{T}">Target</see> values.
        /// </summary>
        /// <remarks>
        /// If your Bot's behavior is static, override <see cref="DefaultTargets">Bot.DefaultTargets</see> instead.
        /// </remarks>
        /// 
        /// <param name="target">List of <see cref="BotFramework.Targets.Target{T}">Targets</see> to give the Bot purpose</param>
        public void SetTargets(ITarget target)
        {
            List<ITarget> targets = new List<ITarget>();
            targets.Add(target);

            this.SetTargets(targets);
        }

        /// <summary>
        /// Manual way of setting <see cref="GameLocation">GameLocation</see> values.
        /// </summary>
        /// <remarks>
        /// If your Bot's behavior is static, override <see cref="DefaultLocations">Bot.DefaultLocations</see> instead.
        /// </remarks>
        /// 
        /// <param name="target">List of <see cref="GameLocation">GameLocations</see> to tell the Bot where you want it to work</param>
        public void SetLocations(IList<GameLocation> locations)
        {
            this._brain.SetLocations(locations);
            this._locationsSet = true;
        }

        /// <summary>
        /// Manual way of setting <see cref="GameLocation">GameLocation</see> values.
        /// </summary>
        /// <remarks>
        /// If your Bot's behavior is static, override <see cref="DefaultLocations">Bot.DefaultLocations</see> instead.
        /// </remarks>
        /// 
        /// <param name="target">List of <see cref="GameLocation">GameLocations</see> to tell the Bot where you want it to work</param>
        public void SetLocations(IList<string> locationNames)
        {
            this._brain.SetLocations(locationNames);
            this._locationsSet = true;
        }

        /// <summary>
        /// Manual way of setting <see cref="GameLocation">GameLocation</see> values.
        /// </summary>
        /// <remarks>
        /// If your Bot's behavior is static, override <see cref="DefaultLocations">Bot.DefaultLocations</see> instead.
        /// </remarks>
        /// 
        /// <param name="target">List of <see cref="GameLocation">GameLocations</see> to tell the Bot where you want it to work</param>
        public void SetLocations(GameLocation location)
        {
            IList<GameLocation> locations = new List<GameLocation>();
            locations.Add(location);

            this.SetLocations(locations);
        }

        /// <summary>
        /// Manual way of setting <see cref="GameLocation">GameLocation</see> values.
        /// </summary>
        /// <remarks>
        /// If your Bot's behavior is static, override <see cref="DefaultLocations">Bot.DefaultLocations</see> instead.
        /// </remarks>
        /// 
        /// <param name="target">List of <see cref="GameLocation">GameLocations</see> to tell the Bot where you want it to work</param>
        public void SetLocations(string locationName)
        {
            IList<string> locationNames = new List<string>();
            locationNames.Add(locationName);

            this.SetLocations(locationNames);
        }

        /// <summary>
        /// Begins the Bot process (trigger).
        /// </summary>
        public void Start()
        {
            if (!this._targetsSet)
            {
                this.DefaultTargets();
            }
            if (!this._locationsSet)
            {
                this.DefaultLocations();
            }

            LogProxy.Info("Bot has been triggered to start");
            this.StartCallback();
            this._active = true;

            this._brain.Start(this._character.GetCurrentLocation());

            IAction action = this._brain.GetNextAction();

            LogProxy.Trace($"{action.ToString()}");
        }

        /// <summary>
        /// Automatically run in absence of <see cref="BotFramework.Targets.Target{T}">Targets</see>.
        /// </summary>
        /// <remarks>
        /// <para>Easiest way to set <see cref="BotFramework.Targets.Target{T}">Targets</see> is by overriding this method.</para>
        /// <para>It will automatically be called and you don't have to worry about instantiating them later.</para>
        /// </remarks>
        protected virtual void DefaultTargets()
        {
            List<ITarget> targets = new List<ITarget>();
            this.SetTargets(targets);
            this._targetsSet = true;
        }

        /// <summary>
        /// Automatically run in absence of <see cref="GameLocation">GameLocations</see>.
        /// </summary>
        /// <remarks>
        /// <para>Easiest way to set <see cref="GameLocation">GameLocations</see> is by overriding this method.</para>
        /// <para>It will automatically be called and you don't have to worry about passing them in later.</para>
        /// </remarks>
        protected virtual void DefaultLocations()
        {
            List<GameLocation> locations = new List<GameLocation>();
            locations.Add(Game1.currentLocation);
            this._brain.SetLocations(locations);
            this._locationsSet = true;
        }

        /// <summary>
        /// Run at the start of the process, optional override
        /// </summary>
        protected virtual void StartCallback()
        {
            LogProxy.Trace("Bot.StartCallback called with no override");
        }

        /// <summary>
        /// Run at the end of the process, optional override
        /// </summary>
        protected virtual void InterruptedCallback()
        {
            LogProxy.Trace("Bot.InterruptedCallback called with no override");
        }

        /// <summary>
        /// Run at the end of the process, optional override
        /// </summary>
        protected virtual void FinishCallback()
        {
            LogProxy.Trace("Bot.FinishCallback called with no override");
        }
    }
}

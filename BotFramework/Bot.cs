using BotFramework.Framework;
using BotFramework.Framework.Helpers;
using BotFramework.Framework.Targets;
using StardewValley;
using System.Collections.Generic;

namespace BotFramework
{
    abstract class Bot
    {
        private bool _active = false;
        private Brain _brain;

        public Bot() : this(Game1.player) { }

        public Bot(Character character)
        {
            this._brain = new Brain();
        }

        public void SetTarget(Target target)
        {
            List<Target> targets = new List<Target>();
            targets.Add(target);

            this._brain.SetTargets(targets);
        }

        public void SetTargets(List<Target> targets)
        {
            this._brain.SetTargets(targets);
        }

        /// <summary>
        /// Sets list of locations by GameLocation objects.
        /// </summary>
        /// 
        /// <param name="locations">List of GameLocation instances</param>
        public void SetLocations(List<GameLocation> locations)
        {
            this._brain.SetLocations(locations);
        }

        /// <summary>
        /// Sets list of locations by location names or unique names.
        /// </summary>
        /// 
        /// <param name="locations">List of GameLocation instances</param>
        public void SetLocations(List<string> locations)
        {
            this._brain.SetLocations(locations);
        }

        /// <summary>
        /// Begins the bot process (trigger).
        /// </summary>
        public void Start()
        {
            LogProxy.Log("Bot has begun work");
            this.StartCallback();
            this._active = true;
        }

        /// <summary>
        /// Run at the start of the process, optional override
        /// </summary>
        protected void StartCallback()
        {
            
        }

        /// <summary>
        /// Run at the end of the process, optional override
        /// </summary>
        protected void InterruptedCallback()
        {

        }

        /// <summary>
        /// Run at the end of the process, optional override
        /// </summary>
        protected void FinishCallback()
        {

        }

        /// <summary>
        /// Action to perform at each block, required override
        /// </summary>
        protected abstract void PerformAction();
    }
}

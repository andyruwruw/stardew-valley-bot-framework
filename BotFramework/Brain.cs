using BotFramework.Actions;
using BotFramework.Helpers;
using BotFramework.World;
using BotFramework.Targets;
using StardewValley;
using System.Collections.Generic;
using System;

namespace BotFramework
{
    /// <summary>
    /// Responsible for maintaining targets and retrieving actions.
    /// </summary>
    class Brain : IBrain
    {
        /// <summary>
        /// All targets of type CallOrder.BeforeEach.
        /// </summary>
        private IList<ITarget> _beforeEachTargets;

        /// <summary>
        /// Queue of CallOrder.BeforeEach actions that take second priority.
        /// </summary>
        private Queue<IAction> _beforeEachQueue;

        /// <summary>
        /// All targets of type CallOrder.AtLocationStart.
        /// </summary>
        private IList<ITarget> _atLocationStartTargets;

        /// <summary>
        /// Queue of CallOrder.AtLocationStart actions that take lowest priority.
        /// </summary>
        private Queue<IAction> _atLocationStartQueue;

        /// <summary>
        /// All targets of type CallOrder.AfterEach.
        /// </summary>
        private IList<ITarget> _afterEachTargets;

        /// <summary>
        /// Queue of CallOrder.AfterEach actions that take highest priority.
        /// </summary>
        private Queue<IAction> _afterEachQueue;

        /// <summary>
        /// Last attempted or run action call order type.
        /// </summary>
        private CallOrder _lastCallOrderType;

        /// <summary>
        /// Generates actions based on locations.
        /// </summary>
        private IWorldParser _world;

        /// <summary>
        /// Instantiates a Bot Brain.
        /// </summary>
        public Brain()
        {
            this.InstantiateTargetLists();
            this.InstantiateActionQueues();

            this._world = new WorldParser();
        }

        /// <summary>
        /// Sets a singluar Target.
        /// </summary>
        /// 
        /// <param name="target"></param>
        /// <exception cref="ArgumentException"/>
        public void SetTarget(ITarget target)
        {
            if (target.GetCallOrder() == CallOrder.BeforeEach || target.GetCallOrder() == CallOrder.AfterEach)
            {
                throw new ArgumentException("At least 1 target must be of type CallOrder.AtLocationStart.");
            }
            this.InstantiateTargetLists();
            this.AddTarget(target);
        }

        /// <summary>
        /// Sets a list of Targets.
        /// </summary>
        /// 
        /// <param name="targets">Bot Targets</param>
        /// <exception cref="ArgumentException"/>
        public void SetTargets(IList<ITarget> targets)
        {
            this.InstantiateTargetLists();

            foreach(ITarget target in targets)
            {
                this.AddTarget(target);
            }

            if (this._atLocationStartTargets.Count == 0)
            {
                throw new ArgumentException("At least 1 target must be of type CallOrder.AtLocationStart.");
            }
        }

        private void AddTarget(ITarget target)
        {
            if (target.GetCallOrder() == CallOrder.BeforeEach)
            {
                this._beforeEachTargets.Add(target);
            } else if (target.GetCallOrder() == CallOrder.AfterEach)
            {
                this._afterEachTargets.Add(target);
            } else
            {
                this._atLocationStartTargets.Add(target);
            }
        }

        public void SetLocation(GameLocation location)
        {
            this._world.SetLocation(location);
        }

        public void SetLocation(string locationName)
        {
            this._world.SetLocation(locationName);
        }

        public void SetLocations(IList<GameLocation> locations)
        {
            this._world.SetLocations(locations);
        }

        public void SetLocations(IList<string> locationNames)
        {
            this._world.SetLocations(locationNames);
        }

        public void Start()
        {
            // Get best tour through locations
            this._world.GenerateActionableLocations();
        }

        public IAction GetNextAction()
        {
            // If all actions are complete, retrieve new
            if (this._beforeEachQueue.Count == 0 && this._afterEachQueue.Count == 0 && this._atLocationStartQueue.Count == 0)
            {
                this.RetrieveAtLocationStartAction();
            }

            // Retrieve new BeforeEach and AfterEach if necessary
            if (this._lastCallOrderType == CallOrder.AtLocationStart)
            {
                this._lastCallOrderType = CallOrder.AfterEach;
                this.RetrieveAfterEachActions();
            }
            if (this._lastCallOrderType == CallOrder.AfterEach && this._afterEachQueue.Count == 0)
            {
                this._lastCallOrderType = CallOrder.BeforeEach;
                this.RetrieveBeforeEachActions();
            }

            // If BeforeEach or AfterEach in queue, return dequeue.
            if (this._afterEachQueue.Count > 0)
            {
                LogProxy.Log("Brain.GetNextAction: Dequeued Action of type CallOrder.AfterEach.", true);
                this._lastCallOrderType = CallOrder.AfterEach;

                return this._afterEachQueue.Dequeue();
            } else if (this._beforeEachQueue.Count > 0)
            {
                LogProxy.Log("Brain.GetNextAction: Dequeued Action of type CallOrder.BeforeEach.", true);
                this._lastCallOrderType = CallOrder.BeforeEach;

                return this._beforeEachQueue.Dequeue();
            }
            
            // If items are in the AtLocationStart queue
            if (this._atLocationStartQueue.Count > 0)
            {
                LogProxy.Log("Brain.GetNextAction: Dequeued Action of type CallOrder.AtLocationStart.", true);
                this._lastCallOrderType = CallOrder.AtLocationStart;

                return this._atLocationStartQueue.Dequeue();
            }

            // Bot is finished
            return null;
        }

        private void RetrieveAtLocationStartAction()
        {
            this._atLocationStartQueue = this._world.GetActions(this._atLocationStartTargets);
        }

        private void RetrieveBeforeEachActions()
        {
            this._beforeEachQueue = this._world.GetActions(this._beforeEachTargets);
        }

        private void RetrieveAfterEachActions()
        {
            this._beforeEachQueue = this._world.GetActions(this._beforeEachTargets);
        }

        private void InstantiateTargetLists()
        {
            this._beforeEachTargets = new List<ITarget>();
            this._atLocationStartTargets = new List<ITarget>();
            this._afterEachTargets = new List<ITarget>();
        }

        private void InstantiateActionQueues()
        {
            this._lastCallOrderType = CallOrder.AfterEach;

            this._beforeEachQueue = new Queue<IAction>();
            this._atLocationStartQueue = new Queue<IAction>();
            this._afterEachQueue = new Queue<IAction>();
        }
    }
}

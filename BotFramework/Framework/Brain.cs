using BotFramework.Framework.Actionable;
using BotFramework.Framework.Helpers;
using BotFramework.Framework.World;
using BotFramework.Framework.Targets;
using StardewValley;
using System.Collections.Generic;

namespace BotFramework.Framework
{
    /// <summary>
    /// Responsible for determining what actions to take next.
    /// </summary>
    class Brain
    {
        private List<Target> _targets;
        private Queue<ActionableTile> _actionQueue;
        private Queue<ActionableLocation> _locationQueue;
        private WorldParser _world;

        public Brain()
        {
            this._actionQueue = new Queue<ActionableTile>();
            this._locationQueue = new Queue<ActionableLocation>();
            this._world = new WorldParser();
        }

        public void SetTargets(List<Target> targets)
        {
            this._targets = targets;
        }

        public void SetLocations(List<GameLocation> locations)
        {
            this._world.SetLocations(locations);
        }

        public void SetLocations(List<string> locations)
        {
            this._world.SetLocations(locations);
        }

        /// <summary>
        /// Retrieve next set of actions from current or next location
        /// </summary>
        /// 
        /// <returns>ActionableTile for next action</returns>
        public ActionableTile GetNextAction()
        {
            if (this._actionQueue.Count == 0)
            {
                if (_locationQueue.Count == 0)
                {
                    return null;
                }

                if (_locationQueue.Peek().isFinished())
                {
                    LogProxy.Log("Brain.GetNextAction: ActionableLocation Popped.", true);
                    _locationQueue.Dequeue();
                }

                if (_locationQueue.Count == 0)
                {
                    LogProxy.Log("Brain.GetNextAction: No More ActionableLocation's.", true);
                    return null;
                }

                List<ActionableTile> actions = _locationQueue.Peek().GetActionableTiles();

                foreach (ActionableTile action in actions)
                {
                    this._actionQueue.Enqueue(action);
                }

                // Figure out how to get to new location
            }

            return this._actionQueue.Dequeue();
        }
    }
}

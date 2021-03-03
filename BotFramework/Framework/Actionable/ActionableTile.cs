using BotFramework.Framework.Location;
using System.Collections.Generic;

namespace BotFramework.Framework.Actionable
{
    /// <summary>
    /// A location to stand, and queue of tiles to run actions on.
    /// </summary>
    class ActionableTile
    {
        private Tile _position;
        private Queue<Tile> _queue;
        private bool _isWarp;

        public ActionableTile()
        {
            this._queue = new Queue<Tile>();
        }

        /// <summary>
        /// Retrieve standing position.
        /// </summary>
        /// 
        /// <returns>Tile position for actionable tile.</returns>
        public Tile GetPosition()
        {
            return this._position;
        }

        /// <summary>
        /// Set standing position.
        /// </summary>
        /// 
        /// <param name="position">Tile position to stand when executing action.</param>
        public void SetPosition(Tile position)
        {
            this._position = position;
        }

        /// <summary>
        /// Removes a Tile from the front of the queue and returns it
        /// </summary>
        /// 
        /// <returns>Removed Tile</returns>
        public Tile Dequeue()
        {
            return this._queue.Dequeue();
        }

        /// <summary>
        /// Adds a Tile to the queue.
        /// </summary>
        /// 
        /// <param name="tile">Tile to be added</param>
        public void Enqueue(Tile tile)
        {
            this._queue.Enqueue(tile);
        }

        /// <summary>
        /// Retrieve the number of items in queue.
        /// </summary>
        /// 
        /// <returns>Integer number of items in queue</returns>
        public int Count()
        {
            return this._queue.Count;
        }
    }
}

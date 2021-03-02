using BotFramework.Framework.Location;
using System.Collections.Generic;

namespace BotFramework.Framework.PlayerControler
{
    /// <summary>
    /// A location to stand, and queue of tiles to run actions on.
    /// </summary>
    class ActionableTile
    {
        private Tile _position;
        private List<Tile> _queue;

        public ActionableTile()
        {
            this._queue = new List<Tile>();
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
        public Tile Pop()
        {
            Tile temp = this._queue[0];
            this._queue.RemoveAt(0);
            return temp;
        }

        /// <summary>
        /// Adds a Tile to the queue.
        /// </summary>
        /// 
        /// <param name="tile">Tile to be added</param>
        public void Add(Tile tile)
        {
            this._queue.Add(tile);
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

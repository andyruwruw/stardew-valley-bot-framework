using BotFramework.Framework.Location;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework.Framework.Actionable
{
    class ActionableLocation
    {
        private LocationParser _parser;
        private bool _warpOnly;
        private ActionableTile _warpTo;
        private Queue<ActionableGroup> _groupQueue;

        public ActionableLocation(GameLocation location, bool warpOnly)
        {
            this._parser = new LocationParser(location);
            this._warpOnly = warpOnly;
            this._groupQueue = new Queue<ActionableGroup>();
        }

        public ActionableLocation(GameLocation location):this(location, false) { }

        public ActionableLocation() : this(Game1.currentLocation, false) { }

        public List<ActionableTile> GetActionableTiles()
        {
            List<ActionableTile> actions = new List<ActionableTile>();

            if (this._warpOnly || (this._groupQueue.Count == 0 && this._warpTo != null))
            {
                actions.Add(this._warpTo);
                return actions;
            }
        }

        public string GetName()
        {
            return this._parser.GetName();
        }

        public bool isFinished()
        {
            return _groupQueue.Count == 0;
        }

        public override bool Equals(object obj)
        {
            return obj is ActionableLocation && this.GetName() == ((ActionableLocation)obj).GetName();
        }
    }
}

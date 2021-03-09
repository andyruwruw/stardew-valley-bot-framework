using BotFramework.Actions;
using BotFramework.Targets;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework
{
    interface IBrain
    {
        void SetTarget(ITarget target);

        void SetTargets(IList<ITarget> targets);

        void SetLocation(GameLocation location);

        void SetLocation(string location);

        void SetLocations(IList<GameLocation> locations);

        void SetLocations(IList<string> locations);

        void Start(GameLocation current);

        IAction GetNextAction();
    }
}

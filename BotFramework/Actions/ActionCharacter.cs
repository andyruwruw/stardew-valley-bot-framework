using BotFramework.Locations;
using BotFramework.Targets;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework.Actions
{
    class ActionCharacter : Action<Character>
    {
        public ActionCharacter(
            ITarget target,
            Character directObject,
            ILocationParser locationParser,
            ActionType actionType = ActionType.Execute
        ) : base(
            target,
            directObject,
            locationParser,
            actionType
        ) { }
    }
}

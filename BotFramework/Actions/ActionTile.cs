using BotFramework.Locations;
using BotFramework.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework.Actions
{
    class ActionTile : Action<ITile>
    {
        public ActionTile(
            ITarget target,
            ITile directObject,
            ILocationParser locationParser,
            ActionType actionType = ActionType.Execute
        ) : base(
            target,
            directObject,
            locationParser,
            actionType
        )
        { }
    }
}

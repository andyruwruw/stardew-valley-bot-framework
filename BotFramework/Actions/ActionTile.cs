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
            ActionType actionType = ActionType.NavigateAndExecute
        ) : base(target, actionType) 
        { }
    }
}

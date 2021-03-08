using BotFramework.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework.Actions
{
    class ActionObject : Action<StardewValley.Object>
    {
        public ActionObject(
            ITarget target,
            ActionType actionType = ActionType.NavigateAndExecute
        ) : base(target, actionType)
        { }
    }
}

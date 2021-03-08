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
            ActionType actionType = ActionType.NavigateAndExecute
        ) : base(target, actionType)
        { }
    }
}

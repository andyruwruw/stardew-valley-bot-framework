using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework
{
    /// <summary>
    /// Loose behavior of actions.
    /// </summary>
    enum ActionType
    {
        /// <summary>
        /// No action is performed upon arrival.
        /// </summary>
        /// <remarks>
        /// Used to travel to warp points.
        /// </remarks>
        Navigate,
        /// <summary>
        /// Navigate to target and execute action.
        /// </summary>
        NavigateAndExecute,
        /// <summary>
        /// Execute action without target.
        /// </summary>
        Execute,
    }
}

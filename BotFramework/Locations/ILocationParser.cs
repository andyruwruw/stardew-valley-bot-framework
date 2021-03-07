﻿using StardewValley;
using System.Collections.Generic;

namespace BotFramework.Locations
{
    interface ILocationParser
    {
        /// <summary>
        /// Retrieve Map instance of location.
        /// </summary>
        /// 
        /// <returns>Map instance of location</returns>
        Map GetMap();

        List<Warp> GetWarps();

        string GetName();
    }
}
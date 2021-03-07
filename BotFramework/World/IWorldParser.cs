using BotFramework.Framework.Actionable;
using BotFramework.Locations;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework.World
{
    interface IWorldParser
    {
        IList<ILocationParser> GetActionableLocations();

        void GenerateActionableLocations();

        /// <summary>
        /// Retrieves GameLocation instance based on location name or unique name.
        /// </summary>
        /// 
        /// <param name="locationName">String name or unique name of GameLocation</param>
        /// <returns></returns>
        GameLocation GetGameLocation(string locationName);

        void SetLocation(GameLocation location);

        void SetLocation(string locationName);

        /// <summary>
        /// Sets locations by GameLocation instances.
        /// </summary>
        /// 
        /// <param name="location">List of GameLocation</param>
        void SetLocations(IList<GameLocation> locations);

        /// <summary>
        /// Sets locations by location names or unique names.
        /// </summary>
        /// 
        /// <param name="location">List of location names or unique names</param>
        void SetLocations(IList<string> locations);
    }
}

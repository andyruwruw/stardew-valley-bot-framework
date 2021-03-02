using BotFramework.Framework.Debug;
using StardewModdingAPI;

namespace BotFramework
{
    /// <summary>
    /// The mod entry point.
    /// </summary>
    public class ModEntry : Mod
    {
        /// <summary>
        /// The mod entry point, called after the mod is first loaded.
        /// </summary>
        /// 
        /// <param name="helper">Provides simplified APIs for writing mods</param>
        public override void Entry(IModHelper helper)
        {
            ModConfig config = this.Helper.ReadConfig<ModConfig>();
            LogProxy.SetDebug(config.DebugEnvironment);
            LogProxy.SetMonitor(this.Monitor);
        }
    }
}
using BotFramework.Helpers;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace BotFramework
{
    /// <summary>
    /// The mod entry point.
    /// </summary>
    public class ModEntry : Mod
    {
        /// <summary>
        /// Mod configuration
        /// </summary>
        public ModConfig config;

        /// <summary>
        /// The mod entry point, called after the mod is first loaded.
        /// </summary>
        /// 
        /// <param name="helper">Provides simplified APIs for writing mods</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.GameLaunched += this.onLaunched;
        }

        private void onLaunched(object sender, GameLaunchedEventArgs e)
        {
            this.config = this.Helper.ReadConfig<ModConfig>();

            LogProxy.SetDebug(this.config.DebugEnvironment);
            LogProxy.SetMonitor(this.Monitor);
        }
    }
}
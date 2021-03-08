using BotFramework.Helpers;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

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
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }

        private void onLaunched(object sender, GameLaunchedEventArgs e)
        {
            this.config = this.Helper.ReadConfig<ModConfig>();

            LogProxy.SetDebug(this.config.DebugEnvironment);
            LogProxy.SetMonitor(this.Monitor);
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            if (e.Button == SButton.U)
            {
                this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
                WaterBotTest bot = new WaterBotTest();

                bot.Start();
            }
        }
    }
}
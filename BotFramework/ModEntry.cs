using BotFramework.Data;
using BotFramework.Test;
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
        /// The mod entry point, called after the mod is first loaded.
        /// </summary>
        ///
        /// <param name="helper">Provides simplified APIs for writing mods</param>
        public override void Entry(IModHelper helper)
		{
			this.SetStaticReferences(helper);
			this.SetEventListeners(helper);
		}

		private void SetStaticReferences(IModHelper helper)
		{
			// Read config file.
			Config.SetConfig(Helper.ReadConfig<ModConfig>());
			// Set static reference to monitor for logging.
			Logger.SetMonitor(Monitor);
        }

		private void SetEventListeners(IModHelper helper)
		{
			helper.Events.GameLoop.UpdateTicked += BotManager.UpdateTicked;
			helper.Events.GameLoop.DayStarted += BotManager.DayStarted;
			helper.Events.Input.ButtonPressed += BotManager.ButtonPressed;
			helper.Events.Player.Warped += BotManager.Warped;
			helper.Events.Input.ButtonPressed += this.OnButtonPressed;
		}

		private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
			if (!Context.IsWorldReady)
			{
				return;
			}

			if (e.Button == SButton.U)
			{
				Logger.Debug($"{Game1.player.Name} pressed {e.Button}.");
				WaterBot bot = new WaterBot();
			}
        }
    }
}
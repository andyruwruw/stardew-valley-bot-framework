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
			helper.Events.GameLoop.UpdateTicked += UpdateTicked;
			helper.Events.GameLoop.DayStarted += DayStarted;
			helper.Events.Input.ButtonPressed += ButtonPressed;
			helper.Events.Player.Warped += Warped;
			helper.Events.Input.ButtonPressed += this.OnButtonPressed;
		}

		private void UpdateTicked(object sender, UpdateTickedEventArgs args)
		{
			if (!Context.IsWorldReady) {
				return;
			}

			BotManager.UpdateTicked(sender, args);
		}

		private void DayStarted(object sender, DayStartedEventArgs args)
		{
			BotManager.DayStarted(sender, args);
		}

		private void ButtonPressed(object sender, ButtonPressedEventArgs args)
		{
			if (!Context.IsWorldReady) {
				return;
			}

			BotManager.ButtonPressed(sender, args);
		}

		private void Warped(object sender, WarpedEventArgs args)
		{
			BotManager.Warped(sender, args);
		}
  }
}
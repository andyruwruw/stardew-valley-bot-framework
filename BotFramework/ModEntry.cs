using BotFramework.Data;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace BotFramework
{
	public class ModEntry : Mod
    {
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
			// Add event listeners.
			helper.Events.GameLoop.UpdateTicked += UpdateTicked;
			helper.Events.GameLoop.DayStarted += DayStarted;
			helper.Events.Input.ButtonPressed += ButtonPressed;
			helper.Events.Player.Warped += Warped;
		}

		private void UpdateTicked(object sender, UpdateTickedEventArgs args)
		{
			if (!Context.IsWorldReady)
			{
				return;
			}

			BotManager.UpdateTicked(sender, args);
		}

		private void DayStarted(object sender, DayStartedEventArgs args)
		{
			if (!Context.IsWorldReady)
			{
				return;
			}

			BotManager.DayStarted(sender, args);
		}

		private void ButtonPressed(object sender, ButtonPressedEventArgs args)
		{
			if (!Context.IsWorldReady)
			{
				return;
			}

			BotManager.ButtonPressed(sender, args);
		}

		private void Warped(object sender, WarpedEventArgs args)
		{
			if (!Context.IsWorldReady)
			{
				return;
			}

			BotManager.Warped(sender, args);
		}
	}
}
using System.Collections.Generic;
using StardewModdingAPI.Events;

namespace BotFramework
{
    class BotManager
	{
		private static IList<IBot> _bots;

		public static void Attatch(IBot bot)
		{
			if (_bots == null)
			{
				_bots = new List<IBot>();
			}

			_bots.Add(bot);
		}

		public static void Detatch(IBot bot)
		{
			if (_bots.Contains(bot))
			{
				_bots.RemoveAt(_bots.IndexOf(bot));
			}
		}

		/// <summary>
		/// Keeps all <see cref="Bot">Bots</see> in the game update loop.
		/// </summary>
		/// 
		/// <param name="sender">Event sender.</param>
		/// <param name="args">Event arguments.</param>
		public static void UpdateTicked(object sender, UpdateTickedEventArgs args)
		{
			foreach (IBot bot in _bots)
			{
				bot.UpdateTicked();
			}
		}

		public static void DayStarted(object sender, DayStartedEventArgs args)
		{
			foreach (IBot bot in _bots)
			{
				bot.DayStarted();
			}
		}

		public static void ButtonPressed(object sender, ButtonPressedEventArgs args)
		{
			foreach (IBot bot in _bots)
			{
				bot.ButtonPressed(args.Button);
			}
		}

		public static void Warped(object sender, WarpedEventArgs args)
		{
			foreach (IBot bot in _bots)
			{
				bot.Warped();
			}
		}
	}
}

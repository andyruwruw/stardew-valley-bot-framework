using BotFramework.Targets;
using StardewValley;

namespace BotFramework
{
	/**
	 * How the bot should start running.
	 */
	enum TriggerType
	{
		/// <summary>
		/// Bot starts when the <see cref="Bot.Start"/> method is called.
		/// </summary>
		Called,
		/// <summary>
		/// Bot starts when a condition is met.
		/// </summary>
		Conditional,
		/// <summary>
		/// Bot is always running.
		/// </summary>
		AlwaysOn,
		/// <summary>
		/// Bot starts when user enters a specific input.
		/// </summary>
		UserInput,
	}
}
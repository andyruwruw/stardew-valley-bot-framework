using BotFramework.Data;

namespace BotFramework
{
    internal class Config
	{
		private static ModConfig _config;

		public static void SetConfig(ModConfig config)
		{
			Config._config = config;
		}
	}
}

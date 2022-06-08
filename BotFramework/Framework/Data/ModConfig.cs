namespace BotFramework.Data
{
	public class ModConfig
    {
		public bool VerboseLogging { get; set; }

		public int MaxTSPGreedyIterations { get; set; }

		public ModConfig()
		{
			this.VerboseLogging = false;
			this.MaxTSPGreedyIterations = 10;
		}
    }
}

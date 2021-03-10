namespace BotFramework
{
    public class ModConfig
    {
        public bool DebugEnvironment { get; set; }

        public int MaxTSPGreedyIterations { get; set; }

        public ModConfig()
        {
            this.DebugEnvironment = false;
        }
    }
}

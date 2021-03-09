using StardewModdingAPI;

namespace BotFramework
{
    /// <summary>
    /// Handles Log Events
    /// </summary>
    class LogProxy
    {
        private static bool _debugConfig;
        private static IMonitor _monitor;

        /// <summary>
        /// Logs message if in debug environment.
        /// </summary>
        ///
        /// <param name="message">Message to be logged</param>
        public static void Log(string message, bool debug = false)
        {
            if (!debug || _debugConfig)
            {
                _monitor.Log(message, LogLevel.Debug);
            }
        }

        /// <summary>
        /// Logs message if in debug environment.
        /// </summary>
        ///
        /// <param name="message">Message to be logged</param>
        public static void Trace(string message)
        {
            _monitor.Log(message, LogLevel.Trace);
        }

        /// <summary>
        /// Logs message.
        /// </summary>
        ///
        /// <param name="message">Message to be logged</param>
        public static void Info(string message)
        {
            _monitor.Log(message, LogLevel.Info);
        }

        /// <summary>
        /// Sets the monitor to log messages to.
        /// </summary>
        ///
        /// <param name="monitor">IMonitor for Mod</param>
        public static void SetMonitor(IMonitor monitor)
        {
            _monitor = monitor;
        }

        /// <summary>
        /// Sets debug mode.
        /// </summary>
        ///
        /// <param name="debug">Whether in debug mode</param>
        public static void SetDebug(bool debug)
        {
            _debugConfig = debug;
        }
    }
}

namespace BotFramework
{
    /// <summary>
    /// Pertaining to call order / condition check. This will impact when target is pulled out of the queue.
    /// </summary>
    enum CallOrder
    {
        /// <summary>
        /// Targets are dequeued on bot start or entry to new GameLocation
        /// </summary>
        AtLocationStart,
        /// <summary>
        /// Targets are dequeued prior to other target's execution. Only before targets not labeled BeforeEach or AfterEach
        /// </summary>
        BeforeEach,
        /// <summary>
        /// Targets are dequeued after other target's execution. Only before targets not labeled BeforeEach or AfterEach
        /// </summary>
        AfterEach,
    }
}

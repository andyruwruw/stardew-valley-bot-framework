namespace BotFramework
{
    /// <summary>
    /// Pertaining to the method targets are found and added to the queue.
    /// </summary>
    enum QueryBehavior
    {
        /// <summary>
        /// Will enqueue all instances of validated targets on GameLocation parsing.
        /// </summary>
        DoForAll,
        /// <summary>
        /// Runs breadth-first search to find nearest instance of validated target to character.
        /// </summary>
        DoForClosest,
        /// <summary>
        /// Finds all, returns one with farthest distance.
        /// </summary>
        DoForFarthest,
        /// <summary>
        /// Runs breadth-first search to find all targets within a range.
        /// </summary>
        WithinRange,
    }
}

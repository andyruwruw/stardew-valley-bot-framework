namespace BotFramework
{
	/// <summary>
	/// Types of <see cref="Behaviors.Behavior">Behaviors</see>.
	/// </summary>
	enum BehaviorType
	{
		/// <summary>
		/// Condition constantly checked to determine whether to trigger behavior.
		/// </summary>
		Reaction = 0,
		/// <summary>
		/// Default action depending on conditions.
		/// </summary>
		Task = 1,
	}
}
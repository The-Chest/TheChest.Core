namespace TheChest.Core.Components
{
    /// <summary>
    /// Represents a stackable collection of items with defined quantity and capacity.
    /// </summary>
    public interface IStackable
    {
        /// <summary>
        /// Defines the amount of items this slot is holding
        /// </summary>
        int Amount { get; }
        /// <summary>
        /// Defines the max amount of item that this slot can contain
        /// </summary>
        int MaxAmount { get; }
        /// <summary>
        /// Defines the amount of available item that this slot can contain.
        /// </summary>
        int AvailableAmount { get; }
    }
}

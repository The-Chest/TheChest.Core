namespace TheChest.Core.Slots.Interfaces
{
    /// <summary>
    /// Represents a slot that can hold item.
    /// </summary>
    /// <typeparam name="T">The type of item the slot can hold</typeparam>
    public interface ISlot<in T>
    {
        /// <summary>
        /// Verify if the slot is full
        /// </summary>
        bool IsFull { get; }
        /// <summary>
        /// Verify if the current slot is empty
        /// </summary>
        bool IsEmpty { get; }
        /// <summary>
        /// Checks if the slot contains the specified item.
        /// </summary>
        /// <param name="item">Item to be checked</param>
        /// <returns><see langword="true"/> if the slot contains the item, otherwise <see langword="false"/></returns>
        bool Contains(T item);
    }
}

namespace TheChest.Core.Slots.Interfaces
{
    /// <summary>
    /// Interface only with properties for a basic Slot
    /// </summary>
    /// <typeparam name="T">Item the Slot Accept</typeparam>
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
        /// <returns>True if the slot contains the item</returns>
        bool Contains(T item);
    }
}

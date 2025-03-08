namespace TheChest.Core.Slots.Interfaces
{
    /// <summary>
    /// Interface only with properties for a basic Slot
    /// </summary>
    /// <typeparam name="T">Item the Slot Accept</typeparam>
    public interface ISlot<out T>
    {
        /// <summary>
        /// The current content inside the slot
        /// </summary>
        T? Content { get; }

        /// <summary>
        /// Verify if the slot is full
        /// </summary>
        bool IsFull { get; }

        /// <summary>
        /// Verify if the current slot is empty
        /// </summary>
        bool IsEmpty { get; }
    }
}

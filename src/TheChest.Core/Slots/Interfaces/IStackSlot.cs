namespace TheChest.Core.Slots.Interfaces
{
    /// <summary>
    /// Generic Container Slot with item stack
    /// </summary>
    /// <typeparam name="T">Item the Slot Accept</typeparam>
    public interface IStackSlot<in T> : ISlot<T>
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
        /// Checks if the slot contains the specified items.
        /// </summary>
        /// <param name="items">items to be checked inside the slot</param>
        /// <returns>true if the slot contains all <paramref name="items"/></returns>
        bool Contains(T[] items);
    }
}

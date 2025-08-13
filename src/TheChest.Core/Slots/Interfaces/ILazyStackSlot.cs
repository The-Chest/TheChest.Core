namespace TheChest.Core.Slots.Interfaces
{
    /// <summary>
    /// Generic Container Slot with item stack that supports lazy checking
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILazyStackSlot<in T> : ISlot<T>
    {
        /// <summary>
        /// Defines the amount of items this slot is holding
        /// </summary>
        int StackAmount { get; }

        /// <summary>
        /// Defines the max amount of item that this slot can contain
        /// </summary>
        int MaxStackAmount { get; }

        /// <summary>
        /// Checks if the slot contains the specified item with a specific amount.
        /// </summary>
        /// <param name="item">Item to be checked</param>
        /// <param name="amount"></param>
        /// <returns></returns>
        bool Contains(T item, int amount);
    }
}

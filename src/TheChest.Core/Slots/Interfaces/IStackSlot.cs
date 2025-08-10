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
        int StackAmount { get; }

        /// <summary>
        /// Defines the max amount of item that this slot can contain
        /// </summary>
        int MaxStackAmount { get; }

        /// <summary>
        /// Checks if the slot contains the specified item with a specific amount.
        /// </summary>
        /// <remarks>
        /// This method might be moved to an extension method or a different interface in the future. It looks like something only for <see cref="LazyStackSlot{T}"/>
        /// </remarks>
        /// <param name="item">Item to be checked</param>
        /// <param name="amount">Amount of the item to be checked</param>
        /// <returns>True if the slot contains the the minimun amount of <paramref name="amount"/> of the <paramref name="item"/></returns>
        bool Contains(T item, int amount);

        /// <summary>
        /// Checks if the slot contains the specified items.
        /// </summary>
        /// <param name="items">items to be checked inside the slot</param>
        /// <returns>true if the slot contains all <paramref name="items"/></returns>
        bool Contains(params T[] items);
    }
}

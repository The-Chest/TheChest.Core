namespace TheChest.Core.Slots.Interfaces
{
    /// <summary>
    /// Represents a slot that can lazily hold a stack of items of a specified type.
    /// </summary>
    /// <remarks>
    /// <see cref="ILazyStackSlot{T}"/> extends <see cref="ISlot{T}"/>
    /// </remarks>
    /// <typeparam name="T">The type of item the slot can hold</typeparam>
    public interface ILazyStackSlot<in T> : ISlot<T>
    {
        /// <summary>
        /// Defines the amount of items this slot is currently holding
        /// </summary>
        int Amount { get; }
        /// <summary>
        /// Defines the max amount of item that this slot can hold
        /// </summary>
        int MaxAmount { get; }
        /// <summary>
        /// Checks if the slot contains the specified item with a specific amount.
        /// </summary>
        /// <param name="item">Item to be checked</param>
        /// <param name="amount">Amount of items to be checked</param>
        /// <returns>True if the slot contains the item with at least the specified amount</returns>
        bool Contains(T item, int amount);
    }
}

namespace TheChest.Core.Slots.Interfaces
{
    /// <summary>
    /// Represents a slot that can hold a stack of items, providing information about the current and maximum number of items, and supporting containment checks.
    /// </summary>
    /// <remarks> 
    /// <see cref="IStackSlot{T}"/> extends <see cref="ISlot{T}"/>
    /// </remarks>
    /// <typeparam name="T">The type of item the slot can hold</typeparam>
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

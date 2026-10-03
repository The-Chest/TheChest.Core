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
        /// Defines the amount of available item that this slot can contain.
        /// </summary>
        int AvailableAmount { get; }
    }
}

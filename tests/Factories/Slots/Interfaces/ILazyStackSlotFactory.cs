using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Common.Attributes;

namespace TheChest.Core.Tests.Factories.Slots.Interfaces
{
    /// <summary>
    /// Defines a factory for creating instances of <see cref="ILazyStackSlot{T}"/>.
    /// </summary>
    /// <remarks>
    /// This interface provides methods to create stack slots with varying initial states, such as empty, partially filled, or fully filled.
    /// </remarks>
    /// <typeparam name="T">The type of item that the stack slot will hold.</typeparam>
    public interface ILazyStackSlotFactory<T>
    {
        /// <summary>
        /// Creates an <see cref="ILazyStackSlot{T}"/> with no item inside it
        /// </summary>
        /// <returns>An empty <see cref="ILazyStackSlot{T}"/></returns>
        [ReflectionExceptionHandle]
        ILazyStackSlot<T> Empty(int amount = 0, int maxAmount = 10);
        /// <summary>
        /// Creates a new lazy stack slot containing the specified item and quantities.
        /// </summary>
        /// <param name="item">The item to include in the stack slot.</param>
        /// <param name="amount">The initial quantity of the item.</param>
        /// <param name="maxAmount">The maximum quantity allowed in the stack slot.</param>
        /// <returns>A lazy stack slot instance with the specified item and quantities.</returns>
        [ReflectionExceptionHandle]
        ILazyStackSlot<T> WithItem(T item, int amount = 1, int maxAmount = 10);
        /// <summary>
        /// Creates an <see cref="IStackSlot{T}"/> with the max supported amount of items inside it
        /// </summary>
        /// <param name="item">The item that will be inside the created N times inside it <see cref="ILazyStackSlot{T}"/></param>
        /// <returns>A full <see cref="ILazyStackSlot{T}"/></returns>
        [ReflectionExceptionHandle]
        ILazyStackSlot<T> Full(T item, int maxAmount = 10);
    }
}

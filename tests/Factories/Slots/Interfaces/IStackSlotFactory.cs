using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Common.Attributes;

namespace TheChest.Core.Tests.Factories.Slots.Interfaces
{
    /// <summary>
    /// Factory interface to instantiate any <see cref="IStackSlot{T}"/> type
    /// </summary>
    /// <typeparam name="T">Any type of item inside ISlot</typeparam>
    public interface IStackSlotFactory<T>
    {
        /// <summary>
        /// Creates an <see cref="IStackSlot{T}"/> with no item inside it
        /// </summary>
        /// <param name="stackSize">The max amount of items that the created <see cref="IStackSlot{T}"/> can hold</param>
        /// <returns>An empty <see cref="IStackSlot{T}"/></returns>
        [ReflectionExceptionHandle]
        IStackSlot<T> Empty(int stackSize);
        /// <summary>
        /// Creates an <see cref="IStackSlot{T}"/> with an amount of itens and max amount set 
        /// </summary>
        /// <param name="item">item to be added to the created slot</param>
        /// <param name="amount">amount of the item that will be added</param>
        /// <param name="maxAmount">max amount of the item that the created slot can hold</param>
        /// <returns>An Slot with an array of</returns>
        [ReflectionExceptionHandle]
        IStackSlot<T> WithItem(T item, int amount, int maxAmount);
        /// <summary>
        /// Creates an <see cref="IStackSlot{T}"/> with the max supported amount of items inside it
        /// </summary>
        /// <param name="item">The item that will be inside the created N times inside it <see cref="IStackSlot{T}"/></param>
        /// <param name="stackSize">The max amount of items that the created <see cref="IStackSlot{T}"/> can hold</param>
        /// <returns>A full <see cref="IStackSlot{T}"/></returns>
        [ReflectionExceptionHandle]
        IStackSlot<T> Full(T item, int stackSize);
    }
}

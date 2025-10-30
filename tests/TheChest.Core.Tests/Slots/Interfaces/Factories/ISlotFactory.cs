using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Slots.Interfaces.Factories
{
    /// <summary>
    /// Factory interface to instantiate any <see cref="ISlot{T}"/>
    /// </summary>
    /// <typeparam name="T">Any type of item inside ISlot</typeparam>
    public interface ISlotFactory<T>
    {
        /// <summary>
        /// Creates an <see cref="ISlot{T}"/> with no item inside it
        /// </summary>
        /// <returns>An empty <see cref="ISlot{T}"/></returns>
        ISlot<T> EmptySlot();
        /// <summary>
        /// Creates an <see cref="ISlot{T}"/> with an item inside it
        /// </summary>
        /// <param name="item">The item that will be inside the created <see cref="ISlot{T}"/></param>
        /// <returns>A full <see cref="ISlot{T}"/></returns>
        ISlot<T> FullSlot(T item);
    }
}

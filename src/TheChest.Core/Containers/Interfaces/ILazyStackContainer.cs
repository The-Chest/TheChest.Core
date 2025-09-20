using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers.Interfaces
{
    /// <summary>
    /// Interface with the basics of a container
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public interface ILazyStackContainer<in T>
    {
        /// <summary>
        /// Size of the current Container
        /// </summary>
        int Size { get; }
        /// <summary>
        /// Verify if the container is full
        /// </summary>
        bool IsFull { get; }
        /// <summary>
        /// Verify if the container is empty
        /// </summary>
        bool IsEmpty { get; }
        /// <summary>
        /// Gets an <see cref="ILazyStackSlot{T}"/> from the Container
        /// </summary>
        /// <param name="index">Index of a slot</param>
        /// <returns>An <see cref="ILazyStackSlot{T}"/> from inside the container</returns>
        ILazyStackSlot<T> this[int index] { get; }

        /// <summary>
        /// Checks if the container contains an item.
        /// </summary>
        /// <param name="item">Item to be checked</param>
        /// <returns>Returns true when the container contains an <paramref name="item"/> in any of its slots</returns>
        bool Contains(T item);
        /// <summary>
        /// Checks if the container contains an amount of <paramref name="item"/>.
        /// </summary>
        /// <param name="item">Item to be checked</param>
        /// <param name="amount">The minimun amount of <paramref name="item"/> expected</param>
        /// <returns>Returns true when the container contains an <paramref name="amount"/> of <paramref name="item"/> in any of its slots</returns>
        bool Contains(T item, int amount);
    }
}

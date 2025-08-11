using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers.Interfaces
{
    /// <summary>
    /// Interface with the basics of a container
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public interface IContainer<in T>
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
        /// Gets an <see cref="ISlot{T}"/> from the Container
        /// </summary>
        /// <param name="index">Index of a slot</param>
        /// <returns>An <see cref="ISlot{T}"/> from inside the container</returns>
        ISlot<T> this[int index] { get; }
    }
}

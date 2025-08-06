using System.Collections.Generic;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers.Interfaces
{
    /// <summary>
    /// Interface with the basics of a container with <see cref="IStackSlot{T}"/> features
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public interface IStackContainer<T>
    {
        /// <summary>
        /// Gets an item from <see cref="IStackSlot{T}"/>
        /// </summary>
        /// <param name="index">Index of a slot<para>It needs to be smaller than <see cref="IStackContainer{T}.Size"/></para></param>
        /// <returns>An item from <see cref="IStackSlot{T}"/></returns>
        IStackSlot<T> this[int index] { get; }

        /// <summary>
        /// Slots in the Container
        /// </summary>
        IReadOnlyCollection<IStackSlot<T>> Slots { get; }

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
    }
}

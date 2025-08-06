using System.Collections.Generic;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers.Interfaces
{
    /// <summary>
    /// Interface with the basics of a container
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public interface IContainer<out T>
    {
        /// <summary>
        /// Slots in the Container
        /// </summary>
        IReadOnlyCollection<ISlot<T>> Slots { get; }

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
        /// Gets an item from <see cref="ISlot{T}"/>
        /// </summary>
        /// <param name="index">Index of a slot<para>It needs to be smaller than <see cref="IContainer{T}.Size"/></para></param>
        /// <returns>An item from <see cref="ISlot{T}"/></returns>
        ISlot<T> this[int index] { get; }
    }
}

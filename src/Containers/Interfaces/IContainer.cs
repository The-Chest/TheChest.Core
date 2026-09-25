using System.Collections.Generic;
using TheChest.Core.Components;

namespace TheChest.Core.Containers.Interfaces
{
    /// <summary>
    /// Defines a generic container that holds items of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of items that the container can hold.</typeparam>
    public interface IContainer<out T> : IContainer, IEnumerable<T> { }

    /// <summary>
    /// Defines a container that holds content state and exposes its size.
    /// </summary>
    public interface IContainer : IContentState
    {
        /// <summary>
        /// Size of the current Container
        /// </summary>
        int Size { get; }
    }
}

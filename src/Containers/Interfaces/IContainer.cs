using System.Collections.Generic;
using TheChest.Core.Abstractions;

namespace TheChest.Core.Containers.Interfaces
{
    /// <summary>
    /// Defines a generic container that holds items of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of items that the container can hold.</typeparam>
    public interface IContainer<out T> : IContainer, IEnumerable<IEnumerable<T>> { }
}

using System.Collections.Generic;
using TheChest.Core.Abstractions;

namespace TheChest.Core.Containers.Interfaces
{
    /// <summary>
    /// Defines a generic stack-like container that can store items of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of items that the container can hold.</typeparam>
    public interface IStackContainer<out T> : IContainer, IEnumerable<IEnumerable<T>> { }
}

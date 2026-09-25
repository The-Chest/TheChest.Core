using System.Collections.Generic;

namespace TheChest.Core.Containers.Interfaces
{
    /// <summary>
    /// Defines a generic stack-like container that supports lazy evaluation and items of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of items that the container can hold.</typeparam>
    public interface ILazyStackContainer<T> : IContainer, IEnumerable<IEnumerable<T>> { }
}

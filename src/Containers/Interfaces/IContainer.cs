using TheChest.Core.Components;

namespace TheChest.Core.Containers.Interfaces
{
    /// <summary>
    /// Defines a generic container that holds items of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of items that the container can hold.</typeparam>
    public interface IContainer<in T> : IContainer, IContentState { }

    /// <summary>
    /// Defines a generic container that holds items 
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Gets the size of the container.
        /// </summary>
        int Size { get; } 
    }
}

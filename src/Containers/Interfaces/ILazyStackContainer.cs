namespace TheChest.Core.Containers.Interfaces
{
    /// <summary>
    /// Defines a generic stack-like container that supports lazy evaluation and items of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of items that the container can hold.</typeparam>
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
    }
}

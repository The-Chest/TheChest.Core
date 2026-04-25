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

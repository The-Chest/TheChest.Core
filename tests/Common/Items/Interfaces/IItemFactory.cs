namespace TheChest.Core.Tests.Common.Items.Interfaces
{
    /// <summary>
    /// Generic item creation.
    /// There is nothing special about this interface. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IItemFactory<T>
    {
        /// <summary>
        /// Creates an item
        /// </summary>
        /// <returns>Any <see cref="T"/> instance</returns>
        T CreateDefault();
        /// <summary>
        /// Creates an item with every property set to a random value
        /// </summary>
        /// <returns>Any <see cref="T"/> instance</returns>
        T CreateRandom();
        /// <summary>
        /// Creates a new instance of type T with randomized properties based on the specified item.
        /// </summary>
        /// <param name="item">The item to use as a template for generating randomized values.</param>
        /// <returns>A new instance of type T with properties randomized from the provided item.</returns>
        T CreateDifferentFrom(T item);
        /// <summary>
        /// Creates an array of items using <see cref="CreateDefault"/>
        /// </summary>
        /// <param name="amount">Size of the returned array of items</param>
        /// <returns>An <see cref="T[]"/> with size <paramref name="amount"/></returns>
        T[] CreateMany(int amount);
        /// <summary>
        /// Creates an array of items using <see cref="CreateRandom"/>
        /// </summary>
        /// <param name="amount">Size of the returned array of items</param>
        /// <returns>An <see cref="T[]"/> with size <paramref name="amount"/></returns>
        T[] CreateManyRandom(int amount);
    }
}

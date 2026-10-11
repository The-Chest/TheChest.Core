namespace TheChest.Core.Abstractions
{
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

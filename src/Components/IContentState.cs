namespace TheChest.Core.Components
{
    public interface IContentState
    {
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

namespace TheChest.Core.Components
{
    /// <summary>
    /// Defines members for representing the state of content within a slot, indicating whether it is full or empty.
    /// </summary>
    public interface IContentState
    {
        /// <summary>
        /// Verify if the slot is full
        /// </summary>
        bool IsFull { get; }
        /// <summary>
        /// Verify if the current slot is empty
        /// </summary>
        bool IsEmpty { get; }
    }
}

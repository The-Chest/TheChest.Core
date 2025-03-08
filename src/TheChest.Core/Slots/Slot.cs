using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots
{
    /// <summary>
    /// Generic Slot with with <see cref="ISlot{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public class Slot<T> : ISlot<T>
    {
        public virtual T? Content { get; protected set; }

        public virtual bool IsFull => !IsEmpty;

        public virtual bool IsEmpty => Content == null;

        /// <summary>
        /// Creates a basic slot with an item
        /// </summary>
        /// <param name="currentItem">item that belongs to this slot (null if empty)</param>
        public Slot(T? currentItem = default)
        {
            Content = currentItem;
        }
    }
}

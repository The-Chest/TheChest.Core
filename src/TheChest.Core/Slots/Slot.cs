using System;
using System.Collections.Generic;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots
{
    /// <summary>
    /// Generic Slot with with <see cref="ISlot{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public class Slot<T> : ISlot<T>
    {
        /// <summary>
        /// The content of the slot
        /// </summary>
        protected T content;

        /// <inheritdoc/>
        public virtual bool IsFull => !IsEmpty;

        /// <inheritdoc/>
        public virtual bool IsEmpty => EqualityComparer<T>.Default.Equals(content, default!);

        /// <summary>
        /// Creates a basic slot with an item
        /// </summary>
        /// <param name="currentItem">item that belongs to this slot (null if empty)</param>
        public Slot(T currentItem = default!)
        {
            content = currentItem;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public virtual bool Contains(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (this.IsEmpty)
                return false;

            return this.content!.Equals(item);
        }
    }
}

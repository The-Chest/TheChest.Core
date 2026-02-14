using System;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots
{
    /// <summary>
    /// Represents a generic slot that can hold a single item of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of item the slot can hold</typeparam>
    public class Slot<T> : ISlot<T>
    {
        /// <summary>
        /// The content of the slot stored as an object.
        /// <para>Use <see cref="Content"/> to se its value</para>
        /// </summary>
        private object content;
        /// <summary>
        /// The content of the slot
        /// <para>Use this to compare</para>
        /// </summary>
        public virtual T Content
        {
            get
            {
                if (typeof(T).IsValueType && this.content is null)
                    return default!;

                return (T)this.content!;
            }
            protected set
            {
                this.content = value;
            }
        }
        /// <inheritdoc/>
        public virtual bool IsFull => !this.IsEmpty;
        /// <inheritdoc/>
        public virtual bool IsEmpty => this.content is null;

        /// <summary>
        /// Creates an empty slot
        /// </summary>
        public Slot()
        {
            this.content = null;
        }
        /// <summary>
        /// Creates a basic slot with an item
        /// </summary>
        /// <param name="currentItem">item that belongs to this slot (null if empty)</param>
        public Slot(T currentItem)
        {
            this.content = currentItem;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public virtual bool Contains(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (this.IsEmpty)
                return false;

            return this.Content?.Equals(item) ?? false;
        }
    }
}

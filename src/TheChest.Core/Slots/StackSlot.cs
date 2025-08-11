using System;
using System.Collections.Generic;
using System.Linq;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots
{
    /// <summary>
    /// Slot with with <see cref="IStackSlot{T}"/> implementation with a collection of items
    /// </summary>
    /// <typeparam name="T">The item collection inside the slot accepts</typeparam>
    public class StackSlot<T> : IStackSlot<T>
    {
        private const string ITEMAMOUNT_BIGGER_THAN_MAXAMOUNT = "The item amount cannot be bigger than max amount";
        private const string MAXAMOUNT_SMALLER_THAN_ZERO = "The max amount property cannot be smaller than zero";
        private const string AMOUNT_BIGGER_THAN_MAXAMOUNT = "The item amount cannot be bigger than max amount";

        /// <summary>
        /// The content inside the slot
        /// </summary>
        protected readonly T[] content;
        /// <summary>
        /// The maximum amount of items that this slot can hold
        /// </summary>
        protected int maxStackAmount;

        /// <inheritdoc/>
        public virtual int StackAmount => this.content.Count(x => !EqualityComparer<T>.Default.Equals(x, default!));
        /// <inheritdoc/>
        public virtual int MaxStackAmount
        {
            get
            {
                return maxStackAmount;
            }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), MAXAMOUNT_SMALLER_THAN_ZERO);

                if (value < StackAmount)
                    throw new ArgumentOutOfRangeException(nameof(value), AMOUNT_BIGGER_THAN_MAXAMOUNT);

                maxStackAmount = value;
            }
        }

        /// <inheritdoc/>
        public virtual bool IsFull => this.StackAmount == maxStackAmount;
        /// <inheritdoc/>
        public virtual bool IsEmpty => this.StackAmount == 0;

        /// <summary>
        /// Creates a basic <see cref="StackSlot{T}"/> with the max size defined by the array
        /// </summary>
        /// <param name="items">The amount of items to be added to the created slot and also sets the <see cref="IStackSlot{T}.MaxStackAmount"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public StackSlot(T[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            this.maxStackAmount = items.Length;
            this.content = items;
        }

        /// <summary>
        /// Creates a basic <see cref="StackSlot{T}"/> with items and a max size defined by param the <paramref name="maxStackAmount"/>
        /// </summary>
        /// <param name="items">The amount of items to be inside the created slot</param>
        /// <param name="maxStackAmount">Sets the max amount permitted to the slot (cannot be smaller than <paramref name="items"/> size)</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public StackSlot(T[] items, int maxStackAmount)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            if (items.Length > maxStackAmount)
                throw new ArgumentOutOfRangeException(nameof(items), ITEMAMOUNT_BIGGER_THAN_MAXAMOUNT);

            Array.Resize(ref items, maxStackAmount);
            this.content = items;
            this.maxStackAmount = maxStackAmount;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="amount"/> zero or smaller</exception>
        [Obsolete("Use Contains(T item) or Contains(params T[] items) instead")]
        public bool Contains(T item, int amount)
        {
            item = item ?? throw new ArgumentNullException(nameof(item));
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (this.IsEmpty)
                return false;

            return this.content.Contains(item) && this.StackAmount >= amount;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="items"/> contain any null value</exception>
        public bool Contains(T[] items)
        {
            if(items.Length == 0 || this.IsEmpty)
                return false;

            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                if (EqualityComparer<T>.Default.Equals(item, default!))
                    throw new ArgumentNullException(nameof(items), "Items cannot contain null values");

                if (!this.content.Contains(item))
                    return false;
            }

            return true;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public bool Contains(T item)
        {
            item = item ?? throw new ArgumentNullException(nameof(item));

            if (this.IsEmpty)
                return false;

            return this.content.Contains(item);
        }
    }
}

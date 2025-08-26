using System;
using System.Collections.Generic;
using System.Linq;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots
{
    /// <summary>
    /// Slot with with <see cref="IStackSlot{T}"/> implementation which have only one item repeatedly 
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public class LazyStackSlot<T> : IStackSlot<T>
    {
        /// <summary>
        /// The content inside the slot
        /// </summary>
        protected T content;
        /// <summary>
        /// The current amount of items inside the slot
        /// </summary>
        protected int amount;
        /// <summary>
        /// The maximum amount of items that this slot can hold
        /// </summary>
        protected int maxAmount;

        /// <inheritdoc/>
        public virtual int Amount
        {
            get
            {
                return amount;
            }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "The amount property cannot be smaller than zero"
                    );

                if (value > this.maxAmount)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "The item amount cannot be bigger than max amount"

                    );

                this.amount = value;
            }
        }
        /// <inheritdoc/>
        public virtual int MaxAmount
        {
            get
            {
                return maxAmount;
            }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "The max amount property cannot be smaller than zero"
                    );

                if (value < this.amount)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "The item amount cannot be bigger than max amount"
                    );

                this.maxAmount = value;
            }
        }

        /// <inheritdoc/>
        public virtual bool IsFull => this.Amount == this.MaxAmount;
        /// <inheritdoc/>
        public virtual bool IsEmpty => this.Amount == 0;

        /// <summary>
        /// Creates a basic Stack Slot with an amount and max amount
        /// </summary>
        /// <param name="currentItem">The current item to be added</param>
        /// <param name="amount">The amount of <paramref name="currentItem"/> to be added</param>
        /// <param name="maxAmount">The maximum permited amount of <paramref name="currentItem"/> to be added</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public LazyStackSlot(T currentItem = default!, int amount = 1, int maxAmount = 1)
        {
            if (currentItem is null)
                amount = 0;

            this.content = currentItem;
            this.MaxAmount = maxAmount;
            this.Amount = amount;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public bool Contains(T item, int amount)
        {
            item = item ?? 
                throw new ArgumentNullException(nameof(item));
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (this.IsEmpty)
                return false;
            return item.Equals(this.content) && 
                amount <= this.Amount;
        }

        /// <summary>
        /// Checks if the slot contains one of any specified items.
        /// </summary>
        /// <param name="items">items to be checked inside the slot</param>
        /// <returns>true if the slot contains all <paramref name="items"/></returns>
        [Obsolete("Use Contains(T item) or Contains(T item, int amount) instead")]
        public bool Contains(params T[] items)
        {
            if (items.Length == 0)
                return false;
            if (this.IsEmpty)
                return false;
            if (items.Contains(default))
                throw new ArgumentNullException(nameof(items), "Items cannot contain null");

            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                if (EqualityComparer<T>.Default.Equals(item, default!))
                    throw new ArgumentNullException(nameof(items), "Items cannot contain null values");

                if (this.content!.Equals(item) && i > 0)
                    return true;
            }

            return false;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public bool Contains(T item)
        {
            item = item ?? throw new ArgumentNullException(nameof(item));
            if (this.IsEmpty)
                return false;

            return item.Equals(this.content);
        }
    }
}

using System;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots
{
    /// <summary>
    /// Slot with with <see cref="IStackSlot{T}"/> implementation which have only one item repeatedly 
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public class LazyStackSlot<T> : ILazyStackSlot<T>
    {
        /// <summary>
        /// The content inside the slot
        /// </summary>
        private object? content;
        /// <summary>
        /// The content inside the slot
        /// </summary>
        public virtual T Content
        {
            get
            {
#pragma warning disable CS8603
                if (typeof(T).IsValueType && this.content is null)
                    return default;

                return (T)this.content;
#pragma warning restore CS8603
            }
            protected set
            {
                this.content = value;
            }
        }

        /// <summary>
        /// The current amount of items inside the slot
        /// </summary>
        protected int amount;
        /// <inheritdoc/>
        public virtual int Amount
        {
            get
            {
                return amount;
            }
            protected set
            {
                ValidateAmount(value, this.maxAmount);
                this.amount = value;
            }
        }

        /// <summary>
        /// The maximum amount of items that this slot can hold
        /// </summary>
        protected int maxAmount;
        /// <inheritdoc/>
        public virtual int MaxAmount
        {
            get
            {
                return maxAmount;
            }
            protected set
            {
                ValidateAmount(this.amount, value);
                this.maxAmount = value;
            }
        }

        /// <inheritdoc/>
        public virtual bool IsFull => !this.IsEmpty && this.amount == this.maxAmount;
        /// <inheritdoc/>
        public virtual bool IsEmpty => this.amount == 0 || this.content is null;

        /// <summary>
        /// Initializes a new instance of the <see cref="LazyStackSlot{T}"/> class with default values.
        /// </summary>
        /// <remarks>
        /// The slot is initialized with no content, an amount of zero, and a maximum amount of one.
        /// </remarks>
        public LazyStackSlot()
        {
            this.content = null;
            this.amount = 0;
            this.maxAmount = 1;
        }
        /// <summary>
        /// Creates a basic Stack Slot with an amount and max amount
        /// </summary>
        /// <param name="currentItem">The current item to be added</param>
        /// <param name="amount">The amount of <paramref name="currentItem"/> to be added</param>
        /// <param name="maxAmount">The maximum permited amount of <paramref name="currentItem"/> to be added</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public LazyStackSlot(T currentItem, int amount = 1, int maxAmount = 1)
        {
            ValidateAmount(amount, maxAmount);

            this.content = currentItem;
            if (this.content is null)
                amount = 0;

            this.amount = amount;
            this.maxAmount = maxAmount;
        }

        /// <summary>
        /// Validates that the specified <paramref name="amount"/> is within the allowed range from zero to the specified <paramref name="maxAmount"/>.
        /// </summary>
        /// <param name="amount">The amount to be validated.</param>
        /// <param name="maxAmount">The maximum allowed amount.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When <paramref name="amount"/> is less than zero, greater than <paramref name="maxAmount"/>, 
        /// or <paramref name="maxAmount"/> is less than zero.
        /// </exception>
        protected static void ValidateAmount(int amount, int maxAmount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    "The amount property cannot be smaller than zero"
                );
            if (maxAmount < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(maxAmount),
                    "The max amount property cannot be smaller than zero"
                );
            if (amount > maxAmount)
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    "The item amount cannot be bigger than max amount"
                );
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public virtual bool Contains(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (this.IsEmpty)
                return false;

            return item.Equals(this.content);
        }
        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public virtual bool Contains(T item, int amount)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (this.IsEmpty)
                return false;
            return item.Equals(this.content) && 
                amount <= this.Amount;
        }
    }
}

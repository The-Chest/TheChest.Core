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
        private const string AMOUNT_SMALLER_THAN_ZERO = "The amount property cannot be smaller than zero";
        private const string MAXAMOUNT_SMALLER_THAN_ZERO = "The max amount property cannot be smaller than zero";
        private const string AMOUNT_BIGGER_THAN_MAXAMOUNT = "The item amount cannot be bigger than max amount";

        /// <summary>
        /// The current amount of items inside the slot
        /// </summary>
        protected int stackAmount;

        /// <inheritdoc/>
        public virtual int StackAmount
        {
            get
            {
                return stackAmount;
            }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), AMOUNT_SMALLER_THAN_ZERO);

                if (value > maxStackAmount)
                    throw new ArgumentOutOfRangeException(nameof(value), AMOUNT_BIGGER_THAN_MAXAMOUNT);

                stackAmount = value;
            }
        }

        /// <summary>
        /// The maximum amount of items that this slot can hold
        /// </summary>
        protected int maxStackAmount;

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

                if (value < this.stackAmount)
                    throw new ArgumentOutOfRangeException(nameof(value), AMOUNT_BIGGER_THAN_MAXAMOUNT);

                this.maxStackAmount = value;
            }
        }

        /// <inheritdoc/>
        public virtual bool IsFull => StackAmount == MaxStackAmount;

        /// <inheritdoc/>
        public virtual bool IsEmpty => StackAmount == 0;

        /// <summary>
        /// The content inside the slot
        /// </summary>
        protected readonly ICollection<T> content;

        /// <inheritdoc/>
        public virtual IReadOnlyCollection<T> Content => content.ToArray();

        /// <summary>
        /// Creates a basic Stack Slot with an amount and max amount
        /// </summary>
        /// <param name="currentItem">The current item to be added</param>
        /// <param name="amount">The amount of <paramref name="currentItem"/> to be added</param>
        /// <param name="maxStackAmount">The maximum permited amount of <paramref name="currentItem"/> to be added</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public LazyStackSlot(T currentItem, int amount = 1, int maxStackAmount = 1)
        {
            if (EqualityComparer<T>.Default.Equals(currentItem, default!))
                amount = 0;

            this.content = Enumerable.Repeat(currentItem, amount).ToArray();

            this.MaxStackAmount = maxStackAmount;
            this.StackAmount = amount;
        }
    }
}

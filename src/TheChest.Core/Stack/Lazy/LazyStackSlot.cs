﻿using System;
using System.Collections.Generic;
using TheChest.Core.Generics.Stack;
using TheChest.Core.Generics.Stack.Lazy;

namespace TheChest.Core.Stack.Lazy
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

                if (value > maxAmount)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "The item amount cannot be bigger than max amount"

                    );

                amount = value;
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

                if (value < amount)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "The item amount cannot be bigger than max amount"
                    );

                maxAmount = value;
            }
        }

        /// <inheritdoc/>
        public virtual bool IsFull => Amount == MaxAmount && !(content is null);
        /// <inheritdoc/>
        public virtual bool IsEmpty => Amount == 0 || content is null;

        /// <summary>
        /// Creates a basic Stack Slot with an amount and max amount
        /// </summary>
        /// <param name="currentItem">The current item to be added</param>
        /// <param name="amount">The amount of <paramref name="currentItem"/> to be added</param>
        /// <param name="maxAmount">The maximum permited amount of <paramref name="currentItem"/> to be added</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public LazyStackSlot(T currentItem = default!, int amount = 1, int maxAmount = 1)
        {
            content = currentItem;
            MaxAmount = maxAmount;

            if (currentItem is null)
                Amount = 0;
            else
                Amount = amount;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public virtual bool Contains(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (IsEmpty)
                return false;

            return item.Equals(content);
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public virtual bool Contains(T item, int amount)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (IsEmpty)
                return false;
            return item.Equals(content) && 
                amount <= Amount;
        }
    }
}

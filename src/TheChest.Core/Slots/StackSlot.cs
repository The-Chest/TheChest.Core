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
        /// <summary>
        /// The content inside the slot
        /// </summary>
        protected T[] content;

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
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(value), 
                        message: "The item amount property cannot be smaller than zero"
                    );

                if (value > MaxAmount)
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(value),
                        message: "The item amount cannot be bigger than max amount"
                    );

                amount = value;
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
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(value),
                        message: "The max amount property cannot be smaller than zero"
                    );

                if (value < Amount)
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(value),
                        message: "The item amount cannot be bigger than max amount"
                    );

                maxAmount = value;
            }
        }

        /// <inheritdoc/>
        public virtual bool IsFull => this.Amount == this.MaxAmount;
        /// <inheritdoc/>
        public virtual bool IsEmpty => this.Amount == 0;

        /// <summary>
        /// Creates a basic <see cref="StackSlot{T}"/> with the max size defined by the array
        /// </summary>
        /// <param name="items">The amount of items to be added to the created slot and also sets the <see cref="IStackSlot{T}.MaxAmount"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public StackSlot(T[] items)
        {
            this.content = items ?? 
                throw new ArgumentNullException(nameof(items));
            this.MaxAmount = items.Length;
            this.Amount = items.Count(item => !(item is null));
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
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            Array.Resize(ref items, maxStackAmount);
            this.content = items;
            this.MaxAmount = maxStackAmount;
            this.Amount = items.Count(item => !(item is null));
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public virtual bool Contains(T item)
        {
            if(item is null)
                throw new ArgumentNullException(nameof(item));

            if (this.IsEmpty)
                return false;

            return this.content.Contains(item) && this.Amount >= amount;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="items"/> contain any null value</exception>
        public virtual bool Contains(T[] items)
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
    }
}

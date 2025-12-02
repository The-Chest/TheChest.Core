using System;
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
        private object?[] content;
        /// <summary>
        /// 
        /// </summary>
        public virtual T[] Content
        {
            get
            {
                var result = new T[this.MaxAmount];

                for (int i = 0; i < this.MaxAmount; i++)
                {
                    var obj = this.content[i];
                    if(typeof(T).IsValueType && obj is null)
                    {
                        result[i] = default!;
                    }
                    else
                    {
                        result[i] = (T)obj!;
                    }
                }

                return result;
            }
            protected set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));

                if (value.Length != this.MaxAmount)
                {
                    this.content = new object?[value.Length];
                    this.maxAmount = value.Length;
                }

                for (int i = 0; i < value.Length; i++)
                {
                    var item = value[i];

                    if (item is null)
                        continue;

                    this.content[i] = item;
                    this.amount++;
                }
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
                return this.amount;
            }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(value), 
                        message: "The item amount property cannot be smaller than zero"
                    );

                if (value > this.MaxAmount)
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(value),
                        message: "The item amount cannot be bigger than max amount"
                    );

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
                return this.maxAmount;
            }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(value),
                        message: "The max amount property cannot be smaller than zero"
                    );
                if (value < this.Amount)
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(value),
                        message: "The item amount cannot be bigger than max amount"
                    );

                this.maxAmount = value;
            }
        }
        /// <inheritdoc/>
        public virtual bool IsFull => this.Amount == this.MaxAmount;
        /// <inheritdoc/>
        public virtual bool IsEmpty => this.Amount == 0;

        /// <summary>
        /// Creates an empty <see cref="StackSlot{T}"/>
        /// </summary>
        public StackSlot() : this(Array.Empty<T>(), 0) 
        { }
        /// <summary>
        /// Creates an empty <see cref="StackSlot{T}"/> with a defined max size
        /// </summary>
        /// <param name="maxAmount">The MaxSizeAllowed</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="maxAmount"/> is zero or smaller</exception>
        public StackSlot(int maxAmount) : this(Array.Empty<T>(), maxAmount)
        { }
        /// <summary>
        /// Creates a basic <see cref="StackSlot{T}"/> with the max size defined by the array
        /// </summary>
        /// <param name="items">The amount of items to be added to the created slot and also sets the <see cref="IStackSlot{T}.MaxAmount"/></param>
        /// <exception cref="ArgumentNullException">When <paramref name="items"/> is null</exception>
        public StackSlot(T[] items) : this(items, items.Length)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));
        }
        /// <summary>
        /// Creates a basic <see cref="StackSlot{T}"/> with items and a max size defined by param the <paramref name="maxAmount"/>
        /// </summary>
        /// <param name="items">The amount of items to be inside the created slot</param>
        /// <param name="maxAmount">Sets the max amount permitted to the slot (cannot be smaller than <paramref name="items"/> size)</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public StackSlot(T[] items, int maxAmount)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            this.content = new object?[items.Length];
            for (int i = 0; i < items.Length; i++)
                this.content[i] = items[i];

            this.MaxAmount = maxAmount;
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

            return this.Content.Contains(item) && this.Amount >= amount;
        }
        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="items"/> is null or contain any null values</exception>
        public virtual bool Contains(T[] items)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));
            if (items.Length == 0 || this.IsEmpty)
                return false;

            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i] ?? 
                    throw new ArgumentNullException(nameof(items), "Items cannot contain null values");
                if (!this.Content.Contains(item))
                    return false;
            }

            return true;
        }
    }
}

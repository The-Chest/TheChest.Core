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
        private readonly object?[] content;
        /// <summary>
        /// The content inside the slot
        /// </summary>
        public virtual T[] Content
        {
            get
            {
#pragma warning disable CS8601
                var result = new T[this.maxAmount];

                for (int i = 0; i < this.maxAmount; i++)
                {
                    var obj = this.content[i];
                    result[i] = (typeof(T).IsValueType && obj is null) ? default : (T)obj;
                }

                return result;
#pragma warning restore CS8601
            }
            protected set
            {
                ValidateContent(value, this.maxAmount);

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
                ValidateAmount(this.Amount, value);
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
                ValidateAmount(this.Amount, value);
                this.maxAmount = value;
            }
        }

        /// <inheritdoc/>
        public virtual bool IsFull => !this.IsEmpty && this.amount == this.maxAmount;
        /// <inheritdoc/>
        public virtual bool IsEmpty => this.amount == 0;

        /// <summary>
        /// Creates an empty <see cref="StackSlot{T}"/>
        /// </summary>
        public StackSlot() : this(Array.Empty<T>(), 0) { }
        /// <summary>
        /// Creates an empty <see cref="StackSlot{T}"/> with a defined max size
        /// </summary>
        /// <param name="maxAmount">The MaxSizeAllowed</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="maxAmount"/> is smaller than zero</exception>
        public StackSlot(int maxAmount) : this(Array.Empty<T>(), maxAmount) { }
        /// <summary>
        /// Creates a basic <see cref="StackSlot{T}"/> with the max size defined by the array
        /// </summary>
        /// <param name="items">The amount of items to be added to the created slot and also sets the <see cref="IStackSlot{T}.MaxAmount"/></param>
        /// <exception cref="ArgumentNullException">When <paramref name="items"/> is null</exception>
        public StackSlot(T[] items) : this(items, items?.Length ?? 0) { }
        /// <summary>
        /// Creates a basic <see cref="StackSlot{T}"/> with items and a max size defined by param the <paramref name="maxAmount"/>
        /// </summary>
        /// <param name="items">The amount of items to be inside the created slot</param>
        /// <param name="maxAmount">Sets the max amount permitted to the slot (cannot be smaller than <paramref name="items"/> size)</param>
        /// <exception cref="ArgumentNullException">When <paramref name="items"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="maxAmount"/> is smaller than zero or bigger than <paramref name="items"/>.Length</exception>
        public StackSlot(T[] items, int maxAmount)
        {
            ValidateContent(items, maxAmount);

            var contentAmount = 0;
            var contentArray = new object?[items.Length];
            
            for (int i = 0; i < items.Length; i++)
            {
                contentArray[i] = items[i];

                if(contentArray[i] is null) 
                    continue;

                contentAmount++;
            }
            ValidateAmount(contentAmount, maxAmount);

            this.content = contentArray;
            this.amount = contentAmount;
            this.maxAmount = maxAmount;
        }

        /// <summary>
        /// Validates that array is not <see langword="null"/> and does not exceed the maximum allowed number of elements.
        /// </summary>
        /// <param name="items">The array of items to validate.</param>
        /// <param name="maxAmount">The maximum number of elements allowed in the <paramref name="items"/> array.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="items"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When the length of <paramref name="items"/> exceeds <paramref name="maxAmount"/>.</exception>
        protected static void ValidateContent(T[] items, int maxAmount)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));
            if (items.Length > maxAmount)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(items),
                    message: "The content size cannot be bigger than max amount"
                );
        }
        /// <summary>
        /// Validates that amount is within the allowed range.
        /// </summary>
        /// <param name="amount">The amount to be validated.</param>
        /// <param name="maxAmount">The maximum allowed value for <paramref name="amount"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="amount"/> or <paramref name="maxAmount"/> is less than 0, or <paramref name="amount"/> is greater than <paramref name="maxAmount"/>.</exception>
        protected static void ValidateAmount(int amount, int maxAmount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(amount),
                    message: "The item amount cannot be smaller than zero"
                );
            if (maxAmount < 0)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(maxAmount),
                    message: "The max amount cannot be smaller than zero"
                );
            if (amount > maxAmount)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(amount),
                    message: "The item amount cannot be bigger than max amount"
                );
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

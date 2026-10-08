using System;
using System.Collections.Generic;
using TheChest.Core.Extensions;
using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Validators;

namespace TheChest.Core.Slots
{
    /// <summary>
    /// Represents a slot that can hold a stack of items of a specified type, with a configurable maximum capacity.
    /// </summary>
    /// <typeparam name="T">The type of item the slot can hold</typeparam>
    public class StackSlot<T> : IStackSlot<T>
    {
        private object[] content;
        private int amount;
        private int maxAmount;

        private T[] cacheContent;
        private bool isCacheValid;

        /// <summary>
        /// The content inside the slot
        /// </summary>
        public virtual IEnumerable<T> Content
        {
            get
            {
                if (!this.isCacheValid)
                {
                    this.cacheContent = this.content.ToGenericArray<T>();
                    this.isCacheValid = true;
                }

                return this.cacheContent;
            }
            protected set
            {
                ContentValidator.ValidateContent(value, this.maxAmount);

                this.content = value.ToObjectArray();
                this.amount = this.content.Length;

                Array.Resize(ref this.content, maxAmount);

                this.isCacheValid = false;
            }
        }

        /// <inheritdoc/>
        public virtual int Amount
        {
            get
            {
                return this.amount;
            }
            protected set
            {
                AmountValidator.ValidateAmount(value, this.maxAmount);
                this.amount = value;

                this.isCacheValid = false;
            }
        }
        /// <inheritdoc/>
        public virtual int MaxAmount
        {
            get
            {
                return this.maxAmount;
            }
            protected set
            {
                AmountValidator.ValidateAmount(this.amount, value);
                Array.Resize(ref this.content, value);
                this.maxAmount = value;
                this.isCacheValid = false;
            }
        }

        /// <inheritdoc/>
        public virtual int AvailableAmount => this.maxAmount - this.amount;
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
        /// <param name="maxAmount">The Max Size Allowed</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="maxAmount"/> is smaller than zero</exception>
        public StackSlot(int maxAmount) : this(Array.Empty<T>(), maxAmount) { }
        /// <summary>
        /// Creates a basic <see cref="StackSlot{T}"/> with the max size defined by the array
        /// </summary>
        /// <param name="items">The amount of items to be added to the created slot and also sets the <see cref="MaxAmount"/></param>
        /// <exception cref="ArgumentNullException">When <paramref name="items"/> is <see langword="null"/></exception>
        public StackSlot(T[] items) : this(items, items?.Length ?? 0) { }
        /// <summary>
        /// Creates a basic <see cref="StackSlot{T}"/> with items and a max size defined by param the <paramref name="maxAmount"/>
        /// </summary>
        /// <param name="items">The amount of items to be inside the created slot</param>
        /// <param name="maxAmount">Sets the max amount permitted to the slot (cannot be smaller than <paramref name="items"/> size)</param>
        /// <exception cref="ArgumentNullException">When <paramref name="items"/> is <see langword="null"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="maxAmount"/> is smaller than zero or bigger than <paramref name="items"/>.Length</exception>
        public StackSlot(T[] items, int maxAmount)
        {
            this.MaxAmount = maxAmount;
            this.Content = items;
        }

    }
}

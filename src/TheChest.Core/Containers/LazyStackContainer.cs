using System;
using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Extensions;
using TheChest.Core.Slots;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers
{
    /// <summary>
    /// Represents a stack-like container providing operations with lazy evaluation capabilities.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the container.</typeparam>
    public class LazyStackContainer<T> : ILazyStackContainer<T>
    {
        /// <summary>
        /// The collection of slots used to store elements of type <typeparamref name="T"/>.
        /// </summary>
        protected readonly ILazyStackSlot<T>[] slots;
        /// <inheritdoc/>
        public virtual int Size => this.slots.Length;
        /// <inheritdoc/>
        public virtual bool IsFull
        {
            get
            {
                for (int i = 0; i < this.slots.Length; i++)
                {
                    if (!this.slots[i].IsFull)
                        return false;
                }

                return true;
            }
        }
        /// <inheritdoc/>
        public virtual bool IsEmpty
        {
            get
            {
                for (int i = 0; i < this.slots.Length; i++)
                {
                    if (!this.slots[i].IsEmpty)
                        return false;
                }

                return true;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LazyStackContainer{T}"/> class with default size of 20 and max stack size of 1.
        /// </summary>
        public LazyStackContainer() : this(20, 1) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LazyStackContainer{T}"/> class with the specified size and maximum stack size.
        /// </summary>
        /// <param name="size">The number of slots in the container.</param>
        /// <param name="maxStackSize">The maximum stack size for each slot.</param>
        public LazyStackContainer(int size, int maxStackSize)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size), "Size cannot be negative.");
            if (maxStackSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxStackSize));

            this.slots = new ILazyStackSlot<T>[size];
            for (int i = 0; i < size; i++)
            {
                this.slots[i] = new LazyStackSlot<T>(default, 0, maxStackSize);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LazyStackContainer{T}"/> class with the specified items and maximum amount.
        /// </summary>
        /// <param name="items">An array of tuples containing items and their amounts to initialize the slots.</param>
        /// <param name="maxAmount">The maximum amount per slot.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="items"/> is <see langword="null"/> or when an item within <paramref name="items"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="maxAmount"/> is less than or equal to zero, or when an amount within <paramref name="items"/> is less than or equal to zero.</exception>
        public LazyStackContainer((T item, int amount)[] items, int maxAmount)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (maxAmount <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxAmount));

            var lazySlots = new ILazyStackSlot<T>[items.Length];

            for (int i = 0; i < items.Length; i++) 
            {
                var (item, amount) = items[i];
                if (item.IsNull()) 
                    throw new ArgumentNullException(nameof(items), $"Item at index {i} is null.");
                if (amount <= 0)
                    throw new ArgumentOutOfRangeException(nameof(items), $"Amount at index {i} must be greater than zero.");

                lazySlots[i] = new LazyStackSlot<T>(item, amount, maxAmount);
            }

            this.slots = lazySlots;
        }
        /// <summary>
        /// Creates a Container with <see cref="ILazyStackSlot{T}"/> implementation
        /// </summary>
        /// <param name="slots">An array of <see cref="ILazyStackSlot{T}"/></param>
        /// <exception cref="ArgumentNullException">When <paramref name="slots"/> is <see langword="null"/></exception>
        public LazyStackContainer(ILazyStackSlot<T>[] slots)
        {
            this.slots = slots ?? throw new ArgumentNullException(nameof(slots));
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is <see langword="null"/></exception>
        public virtual bool Contains(T item)
        {
            if (item.IsNull())
                throw new ArgumentNullException(nameof(item));

            for (var i = 0; i < this.slots.Length; i++)
            {
                if (this.slots[i].Contains(item))
                    return true;
            }

            return false;
        }
        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is <see langword="null"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="amount"/> zero or smaller</exception>
        public virtual bool Contains(T item, int amount)
        {
            if (item.IsNull()) 
                throw new ArgumentNullException(nameof(item));
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            var amountFound = 0;
            for (var i = 0; i < this.slots.Length; i++)
            {
                var slot = this.slots[i];
                if (slot.Contains(item))
                {
                    amountFound += slot.Amount;
                    if (amountFound >= amount)
                        return true;
                }
            }

            return false;
        }
    }
}

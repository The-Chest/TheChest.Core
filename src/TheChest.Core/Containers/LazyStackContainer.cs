using System;
using TheChest.Core.Containers.Interfaces;
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
        public LazyStackContainer() : this(20, 1) { }
        public LazyStackContainer(int size, int maxStackSize) : this(new (T item, int amount)[size], maxStackSize) { }
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
                if (item is null)
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
            if (item is null)
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
            if (item is null) 
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

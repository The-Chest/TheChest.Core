using System;
using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers
{
    /// <summary>
    /// Represents a stack-like container providing operations for items.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the container.</typeparam>
    public class StackContainer<T> : IStackContainer<T>
    {
        /// <summary>
        /// The collection of slots used to store elements of type <typeparamref name="T"/>.
        /// </summary>
        protected readonly IStackSlot<T>[] slots;
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
        /// Creates an empty Container with <see cref="IStackSlot{T}"/> implementation that can hold one item per slot.
        /// </summary>
        public StackContainer() : this(Array.Empty<T>(), 1) { }
        /// <summary>
        /// Creates a Container with <see cref="IStackSlot{T}"/> implementation and initializes it with the provided size and max stack size.
        /// </summary>
        /// <param name="size">Amount of slots in the container</param>
        /// <param name="maxStackSize">Max stack size for each slot in the container</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="maxStackSize"/> is zero or smaller</exception>
        public StackContainer(int size, int maxStackSize) : this(new T[size], maxStackSize) { }
        /// <summary>
        /// Creates a Container with <see cref="IStackSlot{T}"/> implementation and initializes it with the provided items and max stack size.
        /// </summary>
        /// <param name="items">An array of items to initialize the container with.</param>
        /// <param name="maxStackSize">Max stack size for each slot in the container</param>
        /// <exception cref="ArgumentNullException">When <paramref name="items"/> is null or contains null elements</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="maxStackSize"/> is zero or smaller</exception>
        public StackContainer(T[] items, int maxStackSize)
        {
            if (items == null) 
                throw new ArgumentNullException(nameof(items));
            if (maxStackSize <= 0) 
                throw new ArgumentOutOfRangeException(nameof(maxStackSize), "Max stack size must be greater than zero.");

            this.slots = new IStackSlot<T>[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                //TODO: improve distribution by trying to get maxStackSize equal items in each slot instead of just 1
                var item = items[i] ?? 
                    throw new ArgumentNullException(nameof(items), $"Item at index {i} is null.");
                this.slots[i] = new StackSlot<T>(new T[1] { item }, maxStackSize);
            }
        }
        /// <summary>
        /// Creates a Container with <see cref="IStackSlot{T}"/> implementation
        /// </summary>
        /// <param name="slots">An array of <see cref="IStackSlot{T}"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public StackContainer(IStackSlot<T>[] slots)
        {
            this.slots = slots ?? throw new ArgumentNullException(nameof(slots));
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
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
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
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

using System;
using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers
{
    /// <summary>
    /// Represents a generic container that stores elements of type <typeparamref name="T"/> using an array of slots.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the container.</typeparam>"
    public class Container<T> : IContainer<T>
    {
        /// <summary>
        /// The collection of slots used to store elements of type <typeparamref name="T"/>.
        /// </summary>
        protected ISlot<T>[] slots;
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
        /// Creates an empty Container with a default size of 0 and <see cref="Slot{T}"/> implementation
        /// </summary>
        public Container() : this(Array.Empty<T>(), 0) { }
        /// <summary>
        /// Creates a Container with <see cref="Slot{T}"/> implementation and the size of the provided items array
        /// </summary>
        /// <param name="items">Items to be added to the slots on the container</param>
        /// <exception cref="ArgumentNullException">When <paramref name="items"/> is null</exception>
        public Container(T[] items) : this(items, items.Length) { }
        /// <summary>
        /// Creates a Container with <see cref="Slot{T}"/> implementation
        /// </summary>
        /// <param name="size">Number with the size of the container</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="size"/> is zero or smaller</exception>
        public Container(int size) : this(Array.Empty<T>(), size) { }
        /// <summary>
        /// Creates a Container with <see cref="Slot{T}"/> implementation, provided <paramref name="items"/> and the size of the container is defined by the <paramref name="size"/>
        /// </summary>
        /// <param name="items">Items to be added to the slots on the container</param>
        /// <param name="size">Number with the size of the container</param>
        /// <exception cref="ArgumentNullException">When <paramref name="items"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="size"/> is zero or smaller</exception>
        /// <exception cref="ArgumentException">When <paramref name="items"/> length is bigger than <paramref name="size"/></exception>
        public Container(T[] items, int size)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            if (size < items.Length)
                throw new ArgumentException(
                    $"The provided size ({size}) cannot be smaller than the number of items ({items.Length}).",
                    nameof(size)
                );

            this.slots = new Slot<T>[size];
            for (var i = 0; i < size; i++)
            {
                if (i < items.Length)
                    this.slots[i] = new Slot<T>(items[i]);
                else
                    this.slots[i] = new Slot<T>();
            }
        }
        /// <summary>
        /// Creates a Container with <see cref="ISlot{T}"/> implementation
        /// </summary>
        /// <param name="slots">An array of <see cref="ISlot{T}"/></param>
        /// <exception cref="ArgumentNullException">When <paramref name="slots"/> is <see langword="null"/></exception>
        public Container(ISlot<T>[] slots)
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
                if (this.slots[i].Contains(item))
                {
                    amountFound++;
                    if (amountFound >= amount)
                        return true;
                }
            }

            return false;
        }
    }
}

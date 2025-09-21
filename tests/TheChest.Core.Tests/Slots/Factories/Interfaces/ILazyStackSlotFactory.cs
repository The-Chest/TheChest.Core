﻿using TheChest.Core.Generics.Stack;
using TheChest.Core.Generics.Stack.Lazy;

namespace TheChest.Core.Tests.Slots.Factories.Interfaces
{
    public interface ILazyStackSlotFactory<T>
    {
        /// <summary>
        /// Creates an <see cref="ILazyStackSlot{T}"/> with no item inside it
        /// </summary>
        /// <returns>An empty <see cref="ILazyStackSlot{T}"/></returns>
        ILazyStackSlot<T> EmptySlot();
        /// <summary>
        /// Creates an <see cref="ILazyStackSlot{T}"/> with an amount of itens and max amount set 
        /// </summary>
        /// <param name="item">item to be added to the created slot</param>
        /// <param name="amount">amount of the item that will be added</param>
        /// <param name="maxAmount">max amount of the </param>
        /// <returns>An Slot with an array of</returns>
        ILazyStackSlot<T> WithItem(T item, int amount = 1, int maxAmount = 10);
        /// <summary>
        /// Creates an <see cref="IStackSlot{T}"/> with the max supported amount of items inside it
        /// </summary>
        /// <param name="item">The item that will be inside the created N times inside it <see cref="ILazyStackSlot{T}"/></param>
        /// <returns>A full <see cref="ILazyStackSlot{T}"/></returns>
        ILazyStackSlot<T> FullSlot(T item);
    }
}

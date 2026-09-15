using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TheChest.Core.Containers;
using TheChest.Core.Slots;
using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Tests.Factories.Containers.Interfaces
{
    public interface IStackContainerFactory<T>
    {
        IStackContainer<T> Empty(int size, int stackSize);
        IStackContainer<T> Full(int size, int stackSize, T item = default!);
        IStackContainer<T> ShuffledItems(int size, int stackSize, params T[] items);
    }
}

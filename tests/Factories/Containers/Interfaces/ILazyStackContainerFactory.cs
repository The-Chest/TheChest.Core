using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TheChest.Core.Containers;
using TheChest.Core.Slots;
using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Tests.Factories.Containers.Interfaces
{
    public interface ILazyStackContainerFactory<T>
    {
        ILazyStackContainer<T> Empty(int size = 20, int stackSize = 10);
        ILazyStackContainer<T> Full(int size, int stackSize, T item = default!);
        ILazyStackContainer<T> ShuffledItems(int size, int stackSize, params T[] items);
    }
}

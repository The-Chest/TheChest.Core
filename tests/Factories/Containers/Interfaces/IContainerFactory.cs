using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TheChest.Core.Containers;
using TheChest.Core.Slots;
using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Tests.Factories.Containers.Interfaces
{
    public interface IContainerFactory<T>
    {
        IContainer<T> Empty(int size = 20);
        IContainer<T> Full(int size, T item);
        IContainer<T> WithItemShuffled(int size, T item);
        IContainer<T> WithItemsShuffled(int size, params T[] items);
    }
}

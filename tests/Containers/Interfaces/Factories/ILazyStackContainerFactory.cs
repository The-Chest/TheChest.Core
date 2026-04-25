using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Tests.Containers.Interfaces.Factories
{
    public interface ILazyStackContainerFactory<T>
    {
        ILazyStackContainer<T> Empty(int size = 20);
        ILazyStackContainer<T> Full(int size, int stackSize, T item = default!);
        ILazyStackContainer<T> ShuffledItems(int size, int stackSize, params T[] items);
    }
}

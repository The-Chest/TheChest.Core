using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Tests.Containers.Interfaces.Factories
{
    public interface ILazyStackContainerFactory<T>
    {
        ILazyStackContainer<T> EmptyContainer(int size = 20);
        ILazyStackContainer<T> FullContainer(int size, int stackSize, T item = default!);
        ILazyStackContainer<T> ShuffledItemsContainer(int size, int stackSize, params T[] items);
    }
}

using TheChest.Core.Generics;

namespace TheChest.Core.Tests.Containers.Factories.Interfaces
{
    public interface IContainerFactory<T>
    {
        IContainer<T> EmptyContainer(int size = 20);
        IContainer<T> FullContainer(int size, T item);
        IContainer<T> ShuffledItemContainer(int size, T item);
        IContainer<T> ShuffledItemsContainer(int size, params T[] items);
    }
}

using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Tests.Containers.Interfaces.Factories
{
    public interface IContainerFactory<T>
    {
        IContainer<T> EmptyContainer(int size = 20);
        IContainer<T> FullContainer(int size, T item);
        IContainer<T> ShuffledItemContainer(int size, T item);
        IContainer<T> ShuffledItemsContainer(int size, params T[] items);
    }
}

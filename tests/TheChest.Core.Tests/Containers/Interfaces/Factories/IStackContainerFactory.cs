using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Tests.Containers.Interfaces.Factories
{
    public interface IStackContainerFactory<T>
    {
        IStackContainer<T> EmptyContainer(int size = 20);
        IStackContainer<T> FullContainer(int size, int stackSize, T item = default!);
        IStackContainer<T> ShuffledItemsContainer(int size, int stackSize, params T[] items);
    }
}

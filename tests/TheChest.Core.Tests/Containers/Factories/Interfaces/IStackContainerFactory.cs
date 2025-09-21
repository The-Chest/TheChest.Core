using TheChest.Core.Generics.Stack;

namespace TheChest.Core.Tests.Containers.Factories.Interfaces
{
    public interface IStackContainerFactory<T>
    {
        IStackContainer<T> EmptyContainer(int size = 20);
        IStackContainer<T> FullContainer(int size, int stackSize, T item = default!);
        IStackContainer<T> ShuffledItemsContainer(int size, int stackSize, params T[] items);
    }
}

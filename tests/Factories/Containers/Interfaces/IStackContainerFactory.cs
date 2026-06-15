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

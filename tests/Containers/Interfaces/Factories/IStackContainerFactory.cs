using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Tests.Containers.Interfaces.Factories
{
    public interface IStackContainerFactory<T>
    {
        IStackContainer<T> Empty(int size = 20);
        IStackContainer<T> Full(int size, int stackSize, T item = default!);
        IStackContainer<T> ShuffledItems(int size, int stackSize, params T[] items);
    }
}

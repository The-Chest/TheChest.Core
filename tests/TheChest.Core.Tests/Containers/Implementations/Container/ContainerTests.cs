namespace TheChest.Core.Tests.Containers.Implementations
{
    public abstract partial class ContainerTests<T> : IContainerTests<T>
    {
        protected ContainerTests(IContainerFactory<T> containerFactory, IItemFactory<T> itemFactory) : 
            base(containerFactory, itemFactory)
        {
        }
    }
}

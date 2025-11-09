namespace TheChest.Core.Tests.Containers.Implementations
{
    public abstract partial class LazyStackContainerTests<T> : ILazyStackContainerTests<T>
    {
        protected LazyStackContainerTests(ILazyStackContainerFactory<T> containerFactory, IItemFactory<T> itemFactory) : 
            base(containerFactory, itemFactory)
        {
        }
    }
}

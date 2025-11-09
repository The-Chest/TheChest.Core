namespace TheChest.Core.Tests.Containers.Implementations
{
    public abstract partial class StackContainerTests<T> : IStackContainerTests<T>
    {
        protected StackContainerTests(IStackContainerFactory<T> containerFactory, IItemFactory<T> itemFactory) :
            base(containerFactory, itemFactory)
        {
        }
    }
}

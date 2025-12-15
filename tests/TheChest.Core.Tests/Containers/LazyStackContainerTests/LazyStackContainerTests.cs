using TheChest.Core.Tests.Containers.Factories;
using TheChest.Core.Tests.Items.Classes;
using TheChest.Core.Tests.Items.Structs;
using TheChest.Core.Tests.Slots.Factories;

namespace TheChest.Core.Tests.Containers.LazyStackContainerTests
{
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    public partial class LazyStackContainerTests<T> : ILazyStackContainerTests<T>
    {
        public LazyStackContainerTests() :
            base(
                container => {
                    container.Register<ILazyStackSlotFactory<T>, LazyStackSlotFactory<LazyStackSlot<T>, T>>();
                    container.Register<ILazyStackContainerFactory<T>, LazyStackContainerFactory<LazyStackContainer<T>, T>>();
                }
            )
        { }
    }
}

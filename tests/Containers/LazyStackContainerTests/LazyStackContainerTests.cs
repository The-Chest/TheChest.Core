using TheChest.Core.Tests.Common.Items.ReferenceType;
using TheChest.Core.Tests.Common.Items.ValueType;
using TheChest.Core.Tests.Containers.Interfaces;
using TheChest.Core.Tests.Factories.Containers;
using TheChest.Core.Tests.Factories.Containers.Interfaces;
using TheChest.Core.Tests.Factories.Slots;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Containers.LazyStackContainerTests
{
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    [TestFixture(typeof(TestEnumItem))]
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

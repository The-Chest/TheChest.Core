using TheChest.Core.Tests.Common.Items.ReferenceType;
using TheChest.Core.Tests.Common.Items.ValueType;
using TheChest.Core.Tests.Containers.Interfaces;
using TheChest.Core.Tests.Factories.Containers;
using TheChest.Core.Tests.Factories.Containers.Interfaces;
using TheChest.Core.Tests.Factories.Slots;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    [TestFixture(typeof(TestEnumItem))]
    public partial class StackContainerTests<T> : IStackContainerTests<T>
    {
        public StackContainerTests() :
            base(
                container => {
                    container.Register<IStackSlotFactory<T>, StackSlotFactory<StackSlot<T>, T>>();
                    container.Register<IStackContainerFactory<T>, StackContainerFactory<StackContainer<T>, T>>();
                }
            ) 
        { }
    }
}

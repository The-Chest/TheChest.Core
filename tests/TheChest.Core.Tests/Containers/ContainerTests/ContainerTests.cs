using TheChest.Core.Tests.Containers.Factories;
using TheChest.Core.Tests.Items.Classes;
using TheChest.Core.Tests.Items.Structs;
using TheChest.Core.Tests.Slots.Factories;

namespace TheChest.Core.Tests.Containers.ContainerTests
{
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    public partial class ContainerTests<T> : IContainerTests<T>
    {
        public ContainerTests() : 
            base(
                container => {
                    container
                        .Register<ISlotFactory<T>, SlotFactory<Slot<T>, T>>()
                        .Register<IContainerFactory<T>, ContainerFactory<Container<T>, T>>();
                }
            )
        { }
    }
}

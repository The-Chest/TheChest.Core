using TheChest.Core.Tests.Common.Configurations;
using TheChest.Core.Tests.Common.Items.Interfaces;
using TheChest.Core.Tests.Common.Items.ReferenceType;
using TheChest.Core.Tests.Common.Items.ValueType;
using TheChest.Core.Tests.Factories.Containers;
using TheChest.Core.Tests.Factories.Containers.Interfaces;
using TheChest.Core.Tests.Factories.Slots;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Containers.ContainerTests
{
    [Category("Container")]
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    [TestFixture(typeof(TestEnumItem))]
    public partial class ContainerTests<T> : BaseTest<T>
    {
        protected readonly IContainerFactory<T> containerFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected const int MIN_SIZE_TEST = 10;
        protected const int MAX_SIZE_TEST = 20;

        public ContainerTests() : base(
            container => {
                container
                    .Register<ISlotFactory<T>, SlotFactory<Slot<T>, T>>()
                    .Register<IContainerFactory<T>, ContainerFactory<Container<T>, T>>();
            }
        )
        {
            this.containerFactory = this.configurations.Resolve<IContainerFactory<T>>();
            this.itemFactory = this.configurations.Resolve<IItemFactory<T>>();
        }
    }
}

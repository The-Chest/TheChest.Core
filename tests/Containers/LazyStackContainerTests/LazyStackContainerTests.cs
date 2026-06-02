using TheChest.Core.Tests.Common.Configurations;
using TheChest.Core.Tests.Common.Items.Interfaces;
using TheChest.Core.Tests.Common.Items.ReferenceType;
using TheChest.Core.Tests.Common.Items.ValueType;
using TheChest.Core.Tests.Factories.Containers;
using TheChest.Core.Tests.Factories.Containers.Interfaces;
using TheChest.Core.Tests.Factories.Slots;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Containers.LazyStackContainerTests
{
    [Category("LazyStackContainer")]
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    [TestFixture(typeof(TestEnumItem))]
    public partial class LazyStackContainerTests<T> : BaseTest<T>
    {
        private readonly ILazyStackContainerFactory<T> containerFactory;
        private readonly IItemFactory<T> itemFactory;

        private const int MIN_SIZE_TEST = 10;
        private const int MAX_SIZE_TEST = 20;

        private const int MIN_STACK_SIZE_TEST = 10;
        private const int MAX_STACK_SIZE_TEST = 20;

        public LazyStackContainerTests() :
            base(
                container => {
                    container.Register<ILazyStackSlotFactory<T>, LazyStackSlotFactory<LazyStackSlot<T>, T>>();
                    container.Register<ILazyStackContainerFactory<T>, LazyStackContainerFactory<LazyStackContainer<T>, T>>();
                }
            )
        {
            this.containerFactory = this.configurations.Resolve<ILazyStackContainerFactory<T>>();
            this.itemFactory = this.configurations.Resolve<IItemFactory<T>>();
        }

        private (int size, int stackSize) GenerateRandomSizeAndStackSize() =>
            (this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST), this.random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST));
    }
}

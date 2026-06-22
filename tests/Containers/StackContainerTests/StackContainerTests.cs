using TheChest.Core.Tests.Common.Configurations;
using TheChest.Core.Tests.Common.Items.Interfaces;
using TheChest.Core.Tests.Common.Items.ReferenceType;
using TheChest.Core.Tests.Common.Items.ValueType;
using TheChest.Core.Tests.Factories.Containers;
using TheChest.Core.Tests.Factories.Containers.Interfaces;
using TheChest.Core.Tests.Factories.Slots;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    [Category("StackContainer")]
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    [TestFixture(typeof(TestEnumItem))]
    public partial class StackContainerTests<T> : BaseTest<T>
    {
        protected readonly IStackContainerFactory<T> containerFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected const int MIN_SIZE_TEST = 10;
        protected const int MAX_SIZE_TEST = 20;

        protected const int MIN_STACK_SIZE_TEST = 10;
        protected const int MAX_STACK_SIZE_TEST = 20;

        public StackContainerTests() :
            base(
                container => {
                    container.Register<IStackSlotFactory<T>, StackSlotFactory<StackSlot<T>, T>>();
                    container.Register<IStackContainerFactory<T>, StackContainerFactory<StackContainer<T>, T>>();
                }
            )
        {
            this.containerFactory = this.configurations.Resolve<IStackContainerFactory<T>>();
            this.itemFactory = this.configurations.Resolve<IItemFactory<T>>();
        }

        private (int size, int stackSize) GenerateRandomSizeAndStackSize() =>
        (
            this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST), 
            this.random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST)
        );
    }
}

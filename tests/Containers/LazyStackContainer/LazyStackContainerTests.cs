using NUnit.Framework;
using TheChest.Core.Containers;
using TheChest.Core.Slots;
using TheChest.Core.Tests.Common.Configurations;
using TheChest.Core.Tests.Common.Items.Interfaces;
using TheChest.Core.Tests.Common.Items.ReferenceType;
using TheChest.Core.Tests.Common.Items.ValueType;
using TheChest.Core.Tests.Factories.Containers;
using TheChest.Core.Tests.Factories.Containers.Interfaces;
using TheChest.Core.Tests.Factories.Slots;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Containers.LazyStackContainer
{
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    [TestFixture(typeof(TestEnumItem))]
    public abstract class LazyStackContainerTests<T> : BaseTest<T>
    {
        protected readonly ILazyStackContainerFactory<T> containerFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected const int MIN_SIZE_TEST = 10;
        protected const int MAX_SIZE_TEST = 20;

        protected const int MIN_STACK_SIZE_TEST = 10;
        protected const int MAX_STACK_SIZE_TEST = 20;

        protected LazyStackContainerTests() :
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

        protected (int size, int stackSize) GenerateRandomSizeAndStackSize() =>
        (
            this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST), 
            this.random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST)
        );
    }
}

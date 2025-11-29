using TheChest.Core.Tests.Configurations;

namespace TheChest.Core.Tests.Slots.Interfaces.ILazyStackSlotTests
{
    public abstract partial class ILazyStackSlotTests<T> : BaseTest<T>
    {
        protected readonly ILazyStackSlotFactory<T> slotFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected ILazyStackSlotTests(Action<DIContainer> configure) : base(configure)
        {
            this.slotFactory = this.container.Resolve<ILazyStackSlotFactory<T>>();
            this.itemFactory = this.container.Resolve<IItemFactory<T>>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.container.Dispose();
        }
    }
}

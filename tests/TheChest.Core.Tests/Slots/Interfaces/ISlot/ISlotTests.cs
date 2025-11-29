using TheChest.Core.Tests.Items;
using TheChest.Core.Tests.Configurations;

namespace TheChest.Core.Tests.Slots.Interfaces.ISlots
{
    public abstract partial class ISlotTests<T> : BaseTest<T>
    {
        protected readonly ISlotFactory<T> slotFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected ISlotTests(Action<DIContainer> configure) : base(configure)
        {
            this.slotFactory = this.container.Resolve<ISlotFactory<T>>();
            this.itemFactory = this.container.Resolve<IItemFactory<T>>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.container.Dispose();
        }
    }
}

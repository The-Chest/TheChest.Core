using TheChest.Core.Tests.Configurations;

namespace TheChest.Core.Tests.Slots.Interfaces.ISlotTests
{
    public abstract partial class ISlotTests<T> : BaseTest<T>
    {
        protected readonly ISlotFactory<T> slotFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected ISlotTests(Action<DIContainer> configure) : base(configure)
        {
            this.slotFactory = this.configurations.Resolve<ISlotFactory<T>>();
            this.itemFactory = this.configurations.Resolve<IItemFactory<T>>();
        }
    }
}

using TheChest.Core.Tests.Common.Configurations;
using TheChest.Core.Tests.Common.Configurations.DependencyInjection;
using TheChest.Core.Tests.Common.Items.Interfaces;

namespace TheChest.Core.Tests.Slots.Interfaces.ILazyStackSlotTests
{
    public abstract partial class ILazyStackSlotTests<T> : BaseTest<T>
    {
        protected readonly ILazyStackSlotFactory<T> slotFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected ILazyStackSlotTests(Action<DIContainer> configure) : base(configure)
        {
            this.slotFactory = this.configurations.Resolve<ILazyStackSlotFactory<T>>();
            this.itemFactory = this.configurations.Resolve<IItemFactory<T>>();
        }
    }
}

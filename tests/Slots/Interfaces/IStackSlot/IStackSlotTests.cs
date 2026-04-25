using TheChest.Core.Tests.Common.Configurations;
using TheChest.Core.Tests.Common.Configurations.DependencyInjection;
using TheChest.Core.Tests.Common.Items.Interfaces;

namespace TheChest.Core.Tests.Slots.Interfaces.IStackSlotTests
{
    public abstract partial class IStackSlotTests<T> : BaseTest<T>
    {
        protected readonly IStackSlotFactory<T> slotFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected IStackSlotTests(Action<DIContainer> configure) : base(configure)
        {
            this.slotFactory = this.configurations.Resolve<IStackSlotFactory<T>>();
            this.itemFactory = this.configurations.Resolve<IItemFactory<T>>();
        }
    }
}

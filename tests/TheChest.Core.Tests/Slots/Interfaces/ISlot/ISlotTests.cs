using TheChest.Core.Tests.Items;
using TheChest.Core.Tests.Configurations;

namespace TheChest.Core.Tests.Slots.Interfaces.ISlots
{
    public abstract partial class ISlotTests<T>
    {
        protected readonly ISlotFactory<T> slotFactory;
        protected readonly IItemFactory<T> itemFactory;

        private readonly DIContainer container;

        protected ISlotTests(Action<DIContainer> configure)
        {
            this.container = new DIContainer();

            configure(this.container);

            if (!this.container.IsRegistered<IItemFactory<T>>())
                this.container.Register<IItemFactory<T>, ItemFactory<T>>();

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

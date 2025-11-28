using TheChest.Core.Tests.Configurations;
using TheChest.Core.Tests.Items;

namespace TheChest.Core.Tests.Slots.Interfaces.IStackSlots
{
    public abstract partial class IStackSlotTests<T>
    {
        protected readonly IStackSlotFactory<T> slotFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected Random random;

        private readonly DIContainer container;

        protected IStackSlotTests(Action<DIContainer> configure)
        {
            this.container = new DIContainer();

            configure(this.container);

            this.container.Register<IItemFactory<T>, ItemFactory<T>>();

            this.slotFactory = this.container.Resolve<IStackSlotFactory<T>>();
            this.itemFactory = this.container.Resolve<IItemFactory<T>>();
            this.random = new Random();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.container.Dispose();
        }
    }
}

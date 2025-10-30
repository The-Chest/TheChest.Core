using TheChest.Core.Tests.Items.Interfaces;
using TheChest.Core.Tests.Slots.Interfaces.Factories;

namespace TheChest.Core.Tests.Slots.Interfaces
{
    public abstract partial class IStackSlotTests<T>
    {
        protected readonly IStackSlotFactory<T> slotFactory;
        protected readonly IItemFactory<T> itemFactory;
        protected Random random;

        protected IStackSlotTests(IStackSlotFactory<T> slotFactory, IItemFactory<T> itemFactory)
        {
            this.slotFactory = slotFactory;
            this.itemFactory = itemFactory;
        }

        [SetUp]
        public void Setup()
        {
            random = new Random();
        }
    }
}

using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Factories.Slots
{
    public class StackSlotFactory<T, Y> : IStackSlotFactory<Y> where T : StackSlot<Y>
    {
        public virtual IStackSlot<Y> Empty(int stackSize)
        {
            var type = typeof(T);
            var slot = Activator.CreateInstance(type, stackSize);
            return (IStackSlot<Y>)slot!;
        }

        public virtual IStackSlot<Y> Full(Y item, int stackSize)
        {
            var type = typeof(T);
            var items = new Y[stackSize];
            Array.Fill(items, item);

            var slot = Activator.CreateInstance(type, items, stackSize);
            return (IStackSlot<Y>)slot!;
        }

        public virtual IStackSlot<Y> WithItem(Y item, int amount, int maxAmount)
        {
            var type = typeof(T);
            var items = new Y[amount];

            Array.Fill(items, item);

            var slot = Activator.CreateInstance(type, items, maxAmount);

            return (IStackSlot<Y>)slot!;
        }
    }
}

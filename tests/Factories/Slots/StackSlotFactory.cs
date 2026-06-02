using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Factories.Slots
{
    public class StackSlotFactory<T, Y> : IStackSlotFactory<Y> where T : StackSlot<Y>
    {
        public virtual IStackSlot<Y> Empty()
        {
            var type = typeof(T);
            var slot = Activator.CreateInstance(type);
            return (IStackSlot<Y>)slot!;
        }
        public virtual IStackSlot<Y> Full(Y item)
        {
            var type = typeof(T);

            var size = new Random().Next(1, 10);
            var items = new Y[size];
            Array.Fill(items, item);

            var slot = Activator.CreateInstance(type, items, size);
            return (IStackSlot<Y>)slot!;
        }

        public virtual IStackSlot<Y> WithItems(Y[] items, int amount = 1, int maxAmount = 10)
        {
            return (IStackSlot<Y>)Activator.CreateInstance(typeof(T), items, maxAmount)!;
        }

        public virtual IStackSlot<Y> WithItem(Y item, int amount = 1, int maxAmount = 10)
        {
            var items = new Y[amount];
            Array.Fill(items, item);

            return WithItems(items, amount, maxAmount);
        }
    }
}

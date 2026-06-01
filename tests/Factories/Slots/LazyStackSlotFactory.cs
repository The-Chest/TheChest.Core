using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Factories.Slots
{
    public class LazyStackSlotFactory<T, Y> : ILazyStackSlotFactory<Y> 
        where T : LazyStackSlot<Y>
    {
        public ILazyStackSlot<Y> EmptySlot()
        {
            var type = typeof(T);
            var slot = Activator.CreateInstance(type);
            return (ILazyStackSlot<Y>)slot!;
        }

        public ILazyStackSlot<Y> FullSlot(Y item)
        {
            var type = typeof(T);
            var size = new Random().Next(1, 10);

            var slot = Activator.CreateInstance(type, item, size, size);
            return (ILazyStackSlot<Y>)slot!;
        }

        public ILazyStackSlot<Y> WithItem(Y item, int amount = 1, int maxAmount = 10)
        {
            var type = typeof(T);
            var slot = Activator.CreateInstance(type, item, amount, maxAmount);
            return (ILazyStackSlot<Y>)slot!;
        }
    }
}

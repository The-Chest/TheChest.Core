using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Factories.Slots
{
    public class LazyStackSlotFactory<T, Y> : ILazyStackSlotFactory<Y>  where T : LazyStackSlot<Y>
    {
        private static ILazyStackSlot<Y> Instantiate(object? item, int amount = 1, int maxAmount = 10)
        {
            var slot = Activator.CreateInstance(
                type: typeof(T), 
                args: new object?[3] { 
                    item is null ? default : (Y)item, 
                    amount, 
                    maxAmount 
                }
             );
            return (ILazyStackSlot<Y>)slot!;
        }

        public ILazyStackSlot<Y> Empty(int amount = 1, int maxAmount = 10)
        {
            return Instantiate(null, amount, maxAmount);
        }

        public ILazyStackSlot<Y> Full(Y item, int maxAmount = 10)
        {
            return Instantiate(item, maxAmount, maxAmount);
        }

        public ILazyStackSlot<Y> WithItem(Y item, int amount = 1, int maxAmount = 10)
        {
            return Instantiate(item, amount, maxAmount);
        }
    }
}

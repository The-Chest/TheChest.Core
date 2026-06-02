using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Factories.Slots
{
    public class SlotFactory<T, Y> : ISlotFactory<Y> 
        where T : Slot<Y>
    {
        public virtual ISlot<Y> Empty()
        {
            var type = typeof(T);
            var slot = Activator.CreateInstance(type);
            return (ISlot<Y>)slot!;
        }

        public virtual ISlot<Y> Full(Y item)
        {
            var type = typeof(T);
            var constructor = type.GetConstructor(new Type[1] { typeof(Y?) });
            var slot = constructor!.Invoke(new object[1] { item });
            return (ISlot<Y>)slot;
        }
    }
}

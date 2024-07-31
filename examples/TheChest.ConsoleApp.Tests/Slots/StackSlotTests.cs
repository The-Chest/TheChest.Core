﻿using TheChest.Tests.Slots.Generics;

namespace TheChest.ConsoleApp.Tests.Slots
{
    [TestFixtureSource(nameof(SlotFixtureArgs))]
    public class StackSlotTests : IStackSlotTests<Item>
    {
        static readonly object[] SlotFixtureArgs = {
            new object[] {
                new StackSlotFactory<StackSlot, Item>(),
                new SlotItemFactory<Item>(),
            }
        };

        public StackSlotTests(IStackSlotFactory<Item> slotFactory, ISlotItemFactory<Item> itemFactory) : base(slotFactory, itemFactory)
        {
        }
    }
}

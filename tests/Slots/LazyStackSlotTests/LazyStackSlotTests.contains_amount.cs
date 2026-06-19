using TheChest.Core.Tests.Common.Configurations.Attributes;
using TheChest.Core.Tests.Common.NUnit.TestCases;

namespace TheChest.Core.Tests.Slots.LazyStackSlotTests
{
    public partial class LazyStackSlotTests<T>
    {
        [WrongAmount]
        [Description("Contains throws an ArgumentOutOfRangeException when the amount is less than or equal to zero.")]
        [Category("ContainsAmount")]
        [Category("Behavior")]
        [Category("Exception")]
        public void ContainsAmount_InvalidAmount_ThrowsArgumentOutOfRangeException(int amount)
        {
            var stackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(0, stackSize);

            var item = this.itemFactory.CreateDefault();
            Assert.That(
                () => slot.Contains(item, amount), 
                Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("amount")
            );
        }

        [Test]
        [Description("Contains throws an ArgumentNullException when a null item is passed for reference types.")]
        [Category("ContainsAmount")]
        [Category("Behavior")]
        [Category("Exception")]
        [Category("Reference Type")]
        [IgnoreIfValueType]
        public void ContainsAmount_NullItem_ThrowsArgumentNullException()
        {
            var stackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(0, stackSize);

            Assert.That(
                () => slot.Contains(default!, 1),
                Throws.TypeOf<ArgumentNullException>().And.Property("ParamName").EqualTo("item")
             );
        }

        [Test]
        [Description("Contains returns false when the default value is passed and the slot is empty.")]
        [Category("ContainsAmount")]
        [Category("Result")]
        [Category("Failure")]
        [Category("Value Type")]
        [IgnoreIfReferenceType]
        public void ContainsAmount_NullItem_ReturnFalseIfEmpty()
        {
            var stackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(0, stackSize);

            var amount = this.random.Next(1, stackSize);
            var contains = slot.Contains(default!, amount);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns true when the default value is passed and the slot is full.")]
        [Category("ContainsAmount")]
        [Category("Result")]
        [Category("Success")]
        [Category("Value Type")]
        [IgnoreIfReferenceType]
        public void ContainsAmount_NullItem_ReturnTrueIfFull()
        {
            var stackSize = this.GenerateStackSize();            
            var slot = this.slotFactory.Full(default!, stackSize);

            var amount = this.random.Next(1, stackSize);
            var contains = slot.Contains(default!, amount);

            Assert.That(contains, Is.True);
        }


        [Test]
        [Description("Contains returns false when the slot is empty, regardless of the item passed.")]
        [Category("ContainsAmount")]
        [Category("Result")]
        [Category("Failure")]
        public void ContainsAmount_MaxStackAmountSmallerThanSearchedAmount_ReturnsFalse()
        {
            var stackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, stackSize);
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.WithItem(item, amount, stackSize);

            var paramItem = this.itemFactory.CreateDefault();
            var paramAmount = this.random.Next(stackSize, stackSize * 2);
            var contains = slot.Contains(paramItem, paramAmount);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns false when the amount in the slot is smaller than the searched amount, even if the items match.")]
        [Category("ContainsAmount")]
        [Category("Result")]
        [Category("Failure")]
        public void ContainsAmount_AmountSmallerThanSearchedAmount_ReturnsFalse()
        {
            var stackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, stackSize);
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.WithItem(item, amount, stackSize);

            var paramItem = this.itemFactory.CreateDefault();
            var paramAmount = this.random.Next(stackSize, stackSize * 2);
            var contains = slot.Contains(paramItem, paramAmount);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns true when the amount in the slot is equal to the searched amount and the items match.")]
        [Category("ContainsAmount")]
        [Category("Result")]
        [Category("Success")]
        public void ContainsAmount_AmountEqualThanSearchedAmount_ReturnsTrue()
        {
            var stackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, stackSize);
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.WithItem(item, amount, stackSize);

            var paramItem = this.itemFactory.CreateDefault();
            var paramAmount = amount;
            var contains = slot.Contains(paramItem, paramAmount);

            Assert.That(contains, Is.True);
        }

        [Test]
        [Description("Contains returns true when the amount in the slot is bigger than the searched amount and the items match.")]
        [Category("ContainsAmount")]
        [Category("Result")]
        [Category("Success")]
        public void ContainsAmount_AmountBiggerThanSearchedAmount_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var stackSize = this.GenerateStackSize();
            var amount = this.random.Next(stackSize / 2, stackSize);
            var slot = this.slotFactory.WithItem(item, amount, stackSize);

            var paramItem = this.itemFactory.CreateDefault();
            var paramAmount = this.random.Next(1, amount);
            var contains = slot.Contains(paramItem, paramAmount);

            Assert.That(contains, Is.True);
        }
    }
}

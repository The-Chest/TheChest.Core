using System.Linq;
using NUnit.Framework;
using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Containers.LazyStackContainer
{
    public class ContainsTests<T> : LazyStackContainerTests<T>
    {
        [Test]
		[Description("Contains method throws an exception if the item is null.")]
        [IgnoreIfValueType]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            Assert.That(
                () => container.Contains(default!), 
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo("item")
            );
        }

        [Test]
		[Description("Contains method returns false if the item is the default value and the container is empty.")]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsFalseIfEmpty()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            Assert.That(container.Contains(default!), Is.False);
        }

        [Test]
		[Description("Contains method returns true if the item is the default value and the container is full.")]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsTrueIfFull()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var slot = this.containerFactory.Full(size, stackSize, default!);

            Assert.That(slot.Contains(default!), Is.True);
        }


        [Test]
		[Description("Contains method returns false if the item is not in the container.")]
        public void Contains_EmptyContainer_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            var item = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(item), Is.False);
        }

        [Test]
		[Description("Contains method returns false if all items in the container are different from the parameter item.")]
        public void Contains_AllItemsDifferentFromParam_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.Full(size, stackSize, item);

            var paramItem = this.itemFactory.CreateRandom();
            Assert.That(container.Contains(paramItem), Is.False);
        }

        [Test]
		[Description("Contains method returns true if at least one item in the container is equal to the parameter item.")]
        public void Contains_OneItemEqualsToParam_ReturnsTrue()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateDefault();
            var items = this.itemFactory.CreateManyRandom(size - 1).Append(item).ToArray();
            var container = this.containerFactory.ShuffledItems(size, stackSize, items);

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem), Is.True);
        }
    }
}

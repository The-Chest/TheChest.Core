using NUnit.Framework;
using TheChest.Core.Tests.Common.Items.ValueType;

namespace TheChest.Core.Tests.Common.Items
{
    public class ItemFactoryTests
    {
        [Test]
        public void CreateDifferentFrom_EnumValue_ReturnsDifferentValue()
        {
            var factory = new ItemFactory<TestEnumItem>();

            var item = factory.CreateRandom();
            var differentItem = factory.CreateDifferentFrom(item);

            Assert.That(differentItem, Is.Not.EqualTo(item));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void CreateDifferentFrom_BooleanValue_ReturnsOppositeValue(bool item)
        {
            var factory = new ItemFactory<bool>();

            var differentItem = factory.CreateDifferentFrom(item);

            Assert.That(differentItem, Is.EqualTo(!item));
        }
    }
}

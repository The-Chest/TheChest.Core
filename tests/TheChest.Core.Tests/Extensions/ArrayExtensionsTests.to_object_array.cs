using TheChest.Core.Extensions;
using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Extensions
{
    public partial class ArrayExtensionsTests<T>
    {
        [Test]
        public void ToObjectArray_NullArray_ThrowsArgumentNullException()
        {
            T[] array = null!;

            var exception = Assert.Throws<ArgumentNullException>(() => array.ToObjectArray());

            Assert.That(exception!.ParamName, Is.EqualTo("array"));
        }

        [Test]
        [IgnoreIfReferenceType]
        public void ToObjectArray_ValueTypeArray_ReturnsObjectArrayWithAllValues()
        {
            var first = this.itemFactory.CreateRandom();
            var second = this.itemFactory.CreateRandom();
            var array = new[] { first, second };

            var result = array.ToObjectArray();

            Assert.That(result, Has.Length.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(result[0], Is.EqualTo(first));
                Assert.That(result[1], Is.EqualTo(second));
            });
        }

        [Test]
        [IgnoreIfValueType]
        public void ToObjectArray_ReferenceTypeArrayContainsNulls_ReturnsObjectArrayWithoutNulls()
        {
            var first = this.itemFactory.CreateRandom();
            var second = this.itemFactory.CreateRandom();
            var array = new[] { first, default!, second, default! };

            var result = array.ToObjectArray();

            Assert.That(result, Is.EqualTo(new object[] { first!, second! }));
        }
    }
}

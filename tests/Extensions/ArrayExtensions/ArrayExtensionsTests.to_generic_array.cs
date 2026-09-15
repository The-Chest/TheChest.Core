using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TheChest.Core.Containers;
using TheChest.Core.Slots;
using TheChest.Core.Extensions;

namespace TheChest.Core.Tests.Extensions
{
    public partial class ArrayExtensionsTests<T>
    {
        [Test]
        public void ToGenericArray_ArrayContainsNulls_ReturnsTypedArrayWithoutNulls()
        {
            var first = this.itemFactory.CreateRandom();
            var second = this.itemFactory.CreateRandom();
            var array = new object[] { first!, null!, second!, null! };

            var result = array.ToGenericArray<T>();

            Assert.That(result, Is.EqualTo(new[] { first, second }));
        }
    }
}

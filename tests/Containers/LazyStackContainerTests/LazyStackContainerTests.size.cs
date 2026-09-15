using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TheChest.Core.Containers;
using TheChest.Core.Slots;
namespace TheChest.Core.Tests.Containers.LazyStackContainerTests
{
    public partial class LazyStackContainerTests<T>
    {
        [Test]
		[Description("Size property returns the correct size of the container.")]
        [Category("Size")]
        [Category("Property")]
        public void Size_NoInitialValue_SetsSizeToTwenty()
        {
            var container = this.containerFactory.Empty();

            Assert.That(container.Size, Is.EqualTo(20));
        }
    }
}

﻿namespace TheChest.Core.Tests.Containers
{
    public partial class IStackContainerTests<T>
    {
        [Test]
        public void Size_NoInitialValue_SetsSizeToTwenty()
        {
            var container = this.containerFactory.EmptyContainer();

            Assert.That(container.Size, Is.EqualTo(20));
        }
    }
}

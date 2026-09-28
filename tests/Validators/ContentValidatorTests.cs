using System;
using System.Collections.Generic;
using NUnit.Framework;
using TheChest.Core.Validators;

namespace TheChest.Core.Tests.Validators
{
    public class ContentValidatorTests
    {
        [TestCase(0)]
        [TestCase(3)]
        public void ValidateContent_ContentDoesNotExceedMaximum_DoesNotThrow(int maxAmount)
        {
            var content = new[] { 1, 2, 3 };

            Assert.DoesNotThrow(() => ContentValidator.ValidateContent(content[..maxAmount], maxAmount));
        }

        [Test]
        public void ValidateContent_NullContent_ThrowsArgumentNullException()
        {
            IEnumerable<int>? content = null;

            var exception = Assert.Throws<ArgumentNullException>(
                () => ContentValidator.ValidateContent(content!, 1));

            Assert.That(exception!.ParamName, Is.EqualTo("content"));
        }

        [Test]
        public void ValidateContent_ContentExceedsMaximum_ThrowsArgumentOutOfRangeException()
        {
            var content = new[] { 1, 2 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => ContentValidator.ValidateContent(content, 1));

            Assert.That(exception!.ParamName, Is.EqualTo("content"));
            Assert.That(exception.ActualValue, Is.EqualTo(2));
            Assert.That(exception.Message, Does.StartWith("The content size cannot be bigger than max amount"));
        }
    }
}

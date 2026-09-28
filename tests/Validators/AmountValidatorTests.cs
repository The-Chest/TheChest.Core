using System;
using NUnit.Framework;
using TheChest.Core.Validators;

namespace TheChest.Core.Tests.Validators
{
    public class AmountValidatorTests
    {
        [TestCase(0, 0)]
        [TestCase(0, 10)]
        [TestCase(10, 10)]
        public void ValidateAmount_ValidAmount_DoesNotThrow(int amount, int maxAmount)
        {
            Assert.DoesNotThrow(() => AmountValidator.ValidateAmount(amount, maxAmount));
        }

        [Test]
        public void ValidateAmount_NegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => AmountValidator.ValidateAmount(-1, 10));

            Assert.That(exception!.ParamName, Is.EqualTo("amount"));
            Assert.That(exception.Message, Does.StartWith("The amount cannot be smaller than zero"));
        }

        [Test]
        public void ValidateAmount_NegativeMaxAmount_ThrowsArgumentOutOfRangeException()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => AmountValidator.ValidateAmount(0, -1));

            Assert.That(exception!.ParamName, Is.EqualTo("maxAmount"));
            Assert.That(exception.Message, Does.StartWith("The max amount cannot be smaller than zero"));
        }

        [Test]
        public void ValidateAmount_AmountExceedsMaximum_ThrowsArgumentOutOfRangeException()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => AmountValidator.ValidateAmount(11, 10));

            Assert.That(exception!.ParamName, Is.EqualTo("amount"));
            Assert.That(exception.ActualValue, Is.EqualTo(11));
            Assert.That(exception.Message, Does.StartWith("The amount cannot be bigger than max amount"));
        }
    }
}

using System;
using NUnit.Framework;
using TheChest.Core.Validators;

namespace TheChest.Core.Tests.Validators
{
    public class ArgumentValidatorTests
    {
        private const string ParameterName = "value";
        private const string CustomMessage = "Custom validation message";

        [TestCase(1)]
        [TestCase(int.MaxValue)]
        public void ThrowIfNotPositive_PositiveValue_DoesNotThrow(int value)
        {
            Assert.DoesNotThrow(() => ArgumentValidator.ThrowIfNotPositive(value, ParameterName));
            Assert.DoesNotThrow(() => ArgumentValidator.ThrowIfNotPositive(value, ParameterName, CustomMessage));
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void ThrowIfNotPositive_NonPositiveValue_ThrowsForBothOverloads(int value)
        {
            AssertArgumentOutOfRange(
                Assert.Throws<ArgumentOutOfRangeException>(() => ArgumentValidator.ThrowIfNotPositive(value, ParameterName)),
                expectedMessage: null);
            AssertArgumentOutOfRange(
                Assert.Throws<ArgumentOutOfRangeException>(() => ArgumentValidator.ThrowIfNotPositive(value, ParameterName, CustomMessage)),
                CustomMessage);
        }

        [TestCase(0)]
        [TestCase(int.MaxValue)]
        public void ThrowIfNegative_NonNegativeValue_DoesNotThrow(int value)
        {
            Assert.DoesNotThrow(() => ArgumentValidator.ThrowIfNegative(value, ParameterName));
            Assert.DoesNotThrow(() => ArgumentValidator.ThrowIfNegative(value, ParameterName, CustomMessage));
        }

        [Test]
        public void ThrowIfNegative_NegativeValue_ThrowsForBothOverloads()
        {
            AssertArgumentOutOfRange(
                Assert.Throws<ArgumentOutOfRangeException>(() => ArgumentValidator.ThrowIfNegative(-1, ParameterName)),
                expectedMessage: null);
            AssertArgumentOutOfRange(
                Assert.Throws<ArgumentOutOfRangeException>(() => ArgumentValidator.ThrowIfNegative(-1, ParameterName, CustomMessage)),
                CustomMessage);
        }

        [Test]
        public void ThrowIfNull_NonNullValues_DoNotThrow()
        {
            Assert.DoesNotThrow(() => ArgumentValidator.ThrowIfNull(Array.Empty<int>(), ParameterName));
            Assert.DoesNotThrow(() => ArgumentValidator.ThrowIfNull("content", ParameterName));
            Assert.DoesNotThrow(() => ArgumentValidator.ThrowIfNull("content", ParameterName, CustomMessage));
        }

        [Test]
        public void ThrowIfNull_NullArray_ThrowsArgumentNullException()
        {
            int[]? value = null;

            var exception = Assert.Throws<ArgumentNullException>(
                () => ArgumentValidator.ThrowIfNull(value!, ParameterName));

            Assert.That(exception!.ParamName, Is.EqualTo(ParameterName));
        }

        [Test]
        public void ThrowIfNull_NullValue_ThrowsForBothOverloads()
        {
            string? value = null;

            var defaultException = Assert.Throws<ArgumentNullException>(
                () => ArgumentValidator.ThrowIfNull(value!, ParameterName));
            var customException = Assert.Throws<ArgumentNullException>(
                () => ArgumentValidator.ThrowIfNull(value!, ParameterName, CustomMessage));

            Assert.That(defaultException!.ParamName, Is.EqualTo(ParameterName));
            Assert.That(customException!.ParamName, Is.EqualTo(ParameterName));
            Assert.That(customException.Message, Does.StartWith(CustomMessage));
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        public void ThrowIfBigger_ValueWithinRange_DoesNotThrow(int value, int range)
        {
            Assert.DoesNotThrow(() => ArgumentValidator.ThrowIfBigger(value, range, ParameterName));
            Assert.DoesNotThrow(() => ArgumentValidator.ThrowIfBigger(value, range, ParameterName, CustomMessage));
        }

        [Test]
        public void ThrowIfBigger_ValueExceedsRange_ThrowsForBothOverloads()
        {
            AssertArgumentOutOfRange(
                Assert.Throws<ArgumentOutOfRangeException>(() => ArgumentValidator.ThrowIfBigger(2, 1, ParameterName)),
                expectedMessage: null);

            var customException = Assert.Throws<ArgumentOutOfRangeException>(
                () => ArgumentValidator.ThrowIfBigger(2, 1, ParameterName, CustomMessage));
            AssertArgumentOutOfRange(customException, CustomMessage);
            Assert.That(customException!.ActualValue, Is.EqualTo(2));
        }

        private static void AssertArgumentOutOfRange(ArgumentOutOfRangeException? exception, string? expectedMessage)
        {
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception!.ParamName, Is.EqualTo(ParameterName));
            if (expectedMessage != null)
                Assert.That(exception.Message, Does.StartWith(expectedMessage));
        }
    }
}

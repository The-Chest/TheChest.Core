using System;
using NUnit.Framework;
using TheChest.Core.Validators;

namespace TheChest.Core.Tests.Validators
{
    public class IndexValidatorTests
    {
        private const string ParameterName = "index";
        private const string CustomMessage = "Custom index message";

        [TestCase(0, 1)]
        [TestCase(4, 5)]
        public void ThrowIfIndexOutOfRange_IndexWithinRange_DoesNotThrow(int index, int length)
        {
            Assert.DoesNotThrow(() => IndexValidator.ThrowIfIndexOutOfRange(index, length, ParameterName));
            Assert.DoesNotThrow(() => IndexValidator.ThrowIfIndexOutOfRange(index, length, ParameterName, CustomMessage));
        }

        [TestCase(-1, 1)]
        [TestCase(1, 1)]
        [TestCase(0, 0)]
        public void ThrowIfIndexOutOfRange_InvalidIndex_ThrowsForBothOverloads(int index, int length)
        {
            var defaultException = Assert.Throws<ArgumentOutOfRangeException>(
                () => IndexValidator.ThrowIfIndexOutOfRange(index, length, ParameterName));
            var customException = Assert.Throws<ArgumentOutOfRangeException>(
                () => IndexValidator.ThrowIfIndexOutOfRange(index, length, ParameterName, CustomMessage));

            Assert.That(defaultException!.ParamName, Is.EqualTo(ParameterName));
            Assert.That(customException!.ParamName, Is.EqualTo(ParameterName));
            Assert.That(customException.ActualValue, Is.EqualTo(index));
            Assert.That(customException.Message, Does.StartWith(CustomMessage));
        }
    }
}

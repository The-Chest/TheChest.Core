using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TheChest.Core.Containers;
using TheChest.Core.Slots;
namespace TheChest.Core.Tests.Common.Configurations.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    internal class IgnoreIfPrimitiveTypeAttribute : TypeConditionAttribute
    {
        protected override bool ShouldSkip(Type type) => !type.IsPrimitive;

        protected override string Reason => "Ignored because test does not apply to primitive types.";
    }
}

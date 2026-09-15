using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TheChest.Core.Containers;
using TheChest.Core.Slots;
using System;

namespace TheChest.Core.Tests.Common.Items.ValueType
{
    internal readonly struct TestStructItem
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }

        public TestStructItem(string id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        #if NET6_0_OR_GREATER
        public TestStructItem()
        {
            this.Id = "";
            this.Name = "";
            this.Description = "";
        }
        #endif

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
#if NET5_0_OR_GREATER
            if (obj is not TestStructItem) return false;
#else
            if (!(obj is TestStructItem)) return false;

#endif
            var item = (TestStructItem)obj;
            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Description);
        }
    }
}

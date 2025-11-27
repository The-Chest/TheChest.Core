namespace TheChest.Core.Tests.Items.Structs
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

        public TestStructItem()
        {
            this.Id = "";
            this.Name = "";
            this.Description = "";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not TestStructItem) return false;
            var item = (TestStructItem)obj;
            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Description);
        }
    }
}

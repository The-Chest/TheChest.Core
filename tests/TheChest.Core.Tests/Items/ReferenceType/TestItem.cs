namespace TheChest.Core.Tests.Items.ReferenceType
{
    internal class TestItem
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }

        public TestItem(string id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        public TestItem()
        {
            this.Id = "";
            this.Name = "";
            this.Description = "";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not TestItem) return false;
            var item = obj as TestItem;
            return item?.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Description);
        }
    }
}

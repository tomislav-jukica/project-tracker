namespace ProjectTracker.Domain.Tags
{
    public class Tag
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private Tag() { } // For EF

        public Tag(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tag name cannot be empty.");

            Id = Guid.NewGuid();
            Name = name.Trim();
        }

        public override bool Equals(object? obj)
        {
            return obj is Tag tag && Name.Equals(tag.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Name.ToLowerInvariant().GetHashCode();
        }
    }
}

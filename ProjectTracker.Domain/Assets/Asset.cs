using ProjectTracker.Domain.Tags;

namespace ProjectTracker.Domain.Assets
{
    public class Asset
    {
        private readonly List<AssetVersion> _versions = [];
        private readonly List<Tag> _tags = [];        

        public Guid Id { get; private set; }
        public Guid ProjectId { get; private set; }
        public string Name { get; private set; }
        public AssetType Type { get; private set; }
        public AssetStatus Status { get; private set; }

        internal IReadOnlyCollection<AssetVersion> Versions => _versions.AsReadOnly();
        public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();

        private Asset() { } // For EF

        public Asset(Guid projectId, string name, AssetType type, string initialFilePath)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Asset name cannot be empty.");

            Id = Guid.NewGuid();
            ProjectId = projectId;
            Name = name;
            Type = type;
            Status = AssetStatus.Draft;

            AddVersion(initialFilePath); // Automatically creates v1
        }

        public void AddVersion(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be empty.");

            foreach (var version in _versions)
            {
                version.MarkAsNotCurrent();
            }

            int nextVersionNumber = _versions.Count == 0
                ? 1
                : _versions.Max(v => v.VersionNumber) + 1;

            var newVersion = new AssetVersion(nextVersionNumber, filePath);

            _versions.Add(newVersion);
        }

        public void ChangeStatus(AssetStatus newStatus)
        {
            Status = newStatus;
        }

        public void AddTag(Tag tag)
        {
            ArgumentNullException.ThrowIfNull(tag);

            if (_tags.Contains(tag))
                return; // Already added

            _tags.Add(tag);
        }

        public void RemoveTag(Tag tag)
        {
            ArgumentNullException.ThrowIfNull(tag);
            _tags.Remove(tag);
        }
    }
}

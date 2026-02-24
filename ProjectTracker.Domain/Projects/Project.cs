namespace ProjectTracker.Domain.Projects
{
    public class Project
    {
        private readonly List<Guid> _assetIds = new();

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string RootFolderPath { get; private set; }
        public IReadOnlyCollection<Guid> AssetIds => _assetIds.AsReadOnly();

        private Project() { } // For EF

        public Project(string name, string rootFolderPath)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Project name cannot be empty.");
            if (string.IsNullOrWhiteSpace(rootFolderPath))
                throw new ArgumentException("Root folder path cannot be empty.");

            Id = Guid.NewGuid();
            Name = name.Trim();
            RootFolderPath = rootFolderPath.Trim();
        }

        public void AddAsset(Guid assetId)
        {
            if (_assetIds.Contains(assetId))
                return;

            _assetIds.Add(assetId);
        }

        public void RemoveAsset(Guid assetId)
        {
            _assetIds.Remove(assetId);
        }
    }
}

namespace ProjectTracker.Domain.Assets
{
    public class AssetVersion
    {
        public Guid Id { get; private set; }
        public int VersionNumber { get; private set; }
        public string FilePath { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsCurrent { get; private set; }

        private AssetVersion() { } // For EF later

        internal AssetVersion(int versionNumber, string filePath)
        {
            Id = Guid.NewGuid();
            VersionNumber = versionNumber;
            FilePath = filePath;
            CreatedAt = DateTime.UtcNow;
            IsCurrent = true;
        }

        internal void MarkAsNotCurrent()
        {
            IsCurrent = false;
        }
    }
}

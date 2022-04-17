namespace ImagesTask.Infrastructure.AzureBlobStorage
{
    public class BlobStorageSettings
    {
        public const string SettingName = "BlobStorageSettings";
        public string ConnectionString { get; set; }
        public string ContainerName { get; set; }
    }
}
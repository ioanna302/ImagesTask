using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using ImagesTask.Core.Interfaces;

namespace ImagesTask.Infrastructure.AzureBlobStorage
{
    public class FileStorageService : IFileStorageService
    {
        private readonly BlobContainerClient _container;

        public FileStorageService(BlobContainerClient container)
        {
            _container = container;
            _container.CreateIfNotExists(publicAccessType: Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);

        }

        public async Task<string> UploadFile(IFormFile file, string name)
        {
            string filename = Guid.NewGuid().ToString() + '-' + name;
            BlobClient blob = _container.GetBlobClient(filename);
            try
            {
                await blob.UploadAsync(file.OpenReadStream());
            }
            catch
            {
                return "";
            }

            return blob.Uri.OriginalString;

        }

        public async void DeleteFile(string fullPath)
        {
            Uri uri = new Uri(fullPath, UriKind.RelativeOrAbsolute);
            string filename = Path.GetFileName(uri.LocalPath);
            BlobClient blobClient = _container.GetBlobClient(filename);
            if (blobClient.Exists())
            {
                await blobClient.DeleteAsync();
            }
        }
    }
}

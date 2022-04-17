using Microsoft.AspNetCore.Http;

namespace ImagesTask.Core.Interfaces
{
    public interface IFileStorageService
    {
        void DeleteFile(string fullPath);
        Task<string> UploadFile(IFormFile file, string name);
    }
}
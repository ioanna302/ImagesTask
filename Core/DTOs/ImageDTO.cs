using Microsoft.AspNetCore.Http;
using ImagesTask.Core.Entities;

namespace ImagesTask.Core.DTOs
{
    public class ImageDTO
    {
        public Image? Image { get; set; }/// todo separate fields
        public IFormFile? File { get; set; }
    }
}

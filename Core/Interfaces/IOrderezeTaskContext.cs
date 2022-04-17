using Microsoft.EntityFrameworkCore;
using ImagesTask.Core.Entities;

namespace ImagesTask.Core.Interfaces
{
    public interface IImagesTaskContext
    {
        DbSet<Image> Image { get; set; }

    }
}
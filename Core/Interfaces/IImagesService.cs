using ImagesTask.Core.DTOs;

namespace ImagesTask.Core.Interfaces
{
    /// <summary>
    /// Service responsible managing all Images operations
    /// </summary>
    public interface IImagesService
    {
        /// <summary>
        /// 
        /// Returns all images 
        /// </summary>
        /// <returns></returns>
        Task<List<ImageDTO>> GetImages();

        /// <summary>
        /// Adds the supplied <paramref name="image"/> to the system and returns the Id.
        /// Part of the operation is to store the Image in the blob storage.
        /// </summary>
        Task<int> AddNewImage(ImageDTO image);

        /// <summary>
        /// Deletes the Image with the supplied <paramref name="id"/> from the system 
        /// and deletes the file from the blob storage as well.
        /// </summary>
        Task DeleteImage(int id);
        Task SaveChangesAsync();
    }
}

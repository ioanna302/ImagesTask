

using AutoMapper;
using ImagesTask.Core.DTOs;
using ImagesTask.Core.Entities;
using ImagesTask.Core.Interfaces;

namespace ImagesTask.Core.Services
{
    public class ImagesService : IImagesService
    {
        private readonly ISqlRepository _context;
        private readonly IMapper _imageMapper;
        private readonly IFileStorageService _blobRepository;

        public ImagesService(ISqlRepository context, IFileStorageService blobRepository, IMapper mapper)
        {
            _imageMapper = mapper;
            _context = context;
            _blobRepository = blobRepository;
        }


        public async Task<int> AddNewImage(ImageDTO image)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            string blobPath;

            blobPath = await _blobRepository.UploadFile(image.File, image.Image.Name);


            
            image.Image.ImagePath = blobPath;
            Image imageDAL = _imageMapper.Map<Image>(image);
            
            await _context.Add(imageDAL);

            return imageDAL.Id;
        }

        public async Task DeleteImage(int id)
        {
            var imageDAL = _context.Query.FirstOrDefault(x => x.Id == id);
            if (imageDAL == null)
            {
                throw new NullReferenceException(id.ToString());
            }

            _blobRepository.DeleteFile(imageDAL.ImagePath);
            
            await _context.Delete(imageDAL);
        }

        public async Task<List<ImageDTO>> GetImages()
        {

            List<Image> imagesDAL = await _context.GetAll();
            List<ImageDTO> imageBBL = _imageMapper.Map<List<Image>, List<ImageDTO>>(imagesDAL);
            return imageBBL;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

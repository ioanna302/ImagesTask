using MediatR;
using ImagesTask.Core.DTOs;
using ImagesTask.Core.Interfaces;

namespace ImagesTask.Core.Queries
{
    public class GetImagesQuery : IRequest<List<ImageDTO>>
    {
    }

    public class GetImagesQueryHandler : IRequestHandler<GetImagesQuery, List<ImageDTO>>
    {
        private readonly IImagesService _imagesService;

        public GetImagesQueryHandler(IImagesService imagesService)
        {
            _imagesService = imagesService;
        }


        public async Task<List<ImageDTO>> Handle(GetImagesQuery request, CancellationToken cancellationToken)
        {

            var imageFiles = await _imagesService.GetImages();
            return imageFiles;
        }
    }
}

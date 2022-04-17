using AutoMapper;
using ImagesTask.Core.DTOs;
using ImagesTask.Core.Entities;

namespace ImagesTask.Core.Helpers
{
    public class DTOtoEntityProfile : Profile
    {
        public DTOtoEntityProfile()
        {
            CreateMap<Image, ImageDTO>()
                            .ForPath(dest => dest.Image.Id, opt => opt.MapFrom(x => x.Id))
                            .ForPath(dest => dest.Image.ImagePath, opt => opt.MapFrom(x => x.ImagePath))
                            .ForPath(dest => dest.Image.Description, opt => opt.MapFrom(x => x.Description))
                            .ForPath(dest => dest.Image.Name, opt => opt.MapFrom(x => x.Name))
                            .ReverseMap();
        }
    }
}

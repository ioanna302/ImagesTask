using AutoMapper;
using ImagesApp.Models;
using ImagesTask.Core.DTOs;

namespace ImagesApp.Helpers
{
    public class VMtoDTOProfile : Profile
    {
        public VMtoDTOProfile()
        {
            CreateMap<ImageViewModel, ImageDTO>()
                    .ForPath(dest => dest.Image.Id, opt => opt.MapFrom(x => x.Id))
                    .ForPath(dest => dest.Image.ImagePath, opt => opt.MapFrom(x => x.ImagePath))
                    .ForPath(dest => dest.Image.Description, opt => opt.MapFrom(x => x.Description))
                    .ForPath(dest => dest.Image.Name, opt => opt.MapFrom(x => x.Name))
                    .ForMember(dest => dest.File, opt => opt.MapFrom(x => x.ImageFile))
                    .ReverseMap();
        }
    }

}

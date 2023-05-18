using Agricultural.Application.DTOs.SliderImages;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class SliderImagesProfile : Profile
    {
        public SliderImagesProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<SliderImagesDto, Agricultural.Domain.Entity.SliderImages>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<SliderImagesQueryDto, Agricultural.Domain.Entity.SliderImages>().ReverseMap();
        }
    }
}

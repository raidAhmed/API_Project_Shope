using Agricultural.Application.DTOs.Slider;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class SliderProfile : Profile
    {
        public SliderProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<SliderDto, Agricultural.Domain.Entity.Slider>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<SliderQueryDto, Agricultural.Domain.Entity.Slider>().ReverseMap();
        }
    }
}

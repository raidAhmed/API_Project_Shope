using Agricultural.Application.DTOs.Color;
using Agricultural.Application.DTOs.Product;
using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<ColorDto, Agricultural.Domain.Entity.Color>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<ColorQueryDto, Agricultural.Domain.Entity.Color>().ReverseMap();
            CreateMap<ColorDtoApi, Agricultural.Domain.Entity.Color>().ReverseMap();
        }
    }
}

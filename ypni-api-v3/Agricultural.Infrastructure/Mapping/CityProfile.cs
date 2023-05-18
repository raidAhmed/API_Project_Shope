using Agricultural.Application.DTOs.City;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<CityDto, Agricultural.Domain.Entity.City>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<CityQueryDto, Agricultural.Domain.Entity.City>().ReverseMap();
        }
    }
}

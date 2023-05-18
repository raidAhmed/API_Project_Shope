using Agricultural.Application.DTOs.Unit;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<UnitDto, Agricultural.Domain.Entity.Unit>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<UnitQueryDto, Agricultural.Domain.Entity.Unit>().ReverseMap();
        }
    }
}

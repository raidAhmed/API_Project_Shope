using Agricultural.Application.DTOs.Markets;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class MarketsProfile : Profile
    {
        public MarketsProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<MarketsDto, Agricultural.Domain.Entity.Markets>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<MarketsQueryDto, Agricultural.Domain.Entity.Markets>().ReverseMap();
        }
    }
}

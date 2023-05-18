using Agricultural.Application.DTOs.ProFeatures;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class ProFeaturesProfile : Profile
    {
        public ProFeaturesProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<ProFeaturesDto, Agricultural.Domain.Entity.ProFeatures>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<ProFeaturesQueryDto, Agricultural.Domain.Entity.ProFeatures>().ReverseMap();
        }
    }
}

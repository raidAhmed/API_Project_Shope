using Agricultural.Application.DTOs.SP_ProFeatures;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class SP_ProFeaturesProfile : Profile
    {
        public SP_ProFeaturesProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<SP_ProFeaturesDto, Agricultural.Domain.Entity.SP_ProFeatures>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<SP_ProFeaturesQueryDto, Agricultural.Domain.Entity.SP_ProFeatures>().ReverseMap();
        }
    }
}

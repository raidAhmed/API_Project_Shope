using Agricultural.Application.DTOs.ProviderEvaluation;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class ProviderEvaluationProfile : Profile
    {
        public ProviderEvaluationProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<ProviderEvaluationDto, Agricultural.Domain.Entity.ProviderEvaluation>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<ProviderEvaluationQueryDto, Agricultural.Domain.Entity.ProviderEvaluation>().ReverseMap();
        }
    }
}

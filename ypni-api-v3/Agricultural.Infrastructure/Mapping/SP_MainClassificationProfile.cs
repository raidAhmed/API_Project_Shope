using Agricultural.Application.DTOs.SP_MainClassification;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class SP_MainClassificationProfile : Profile
    {
        public SP_MainClassificationProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<SP_MainClassificationDto, Agricultural.Domain.Entity.SP_MainClassification>().ReverseMap();
          
            //Mapping QueryDto To Entity
            CreateMap<SP_MainClassificationQueryDto, Agricultural.Domain.Entity.SP_MainClassification>().ReverseMap();
        }
    }
}

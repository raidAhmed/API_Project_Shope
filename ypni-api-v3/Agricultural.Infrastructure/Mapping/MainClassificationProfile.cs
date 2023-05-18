using Agricultural.Application.DTOs.MainClassification;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class MainClassificationProfile : Profile
    {
        public MainClassificationProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<MainClassificationDto, Agricultural.Domain.Entity.MainClassification>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<MainClassificationQueryDto, Agricultural.Domain.Entity.MainClassification>().ReverseMap();
        }
    }
}

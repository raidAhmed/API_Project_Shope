using Agricultural.Application.DTOs.SupportRequest;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class SupportRequestProfile : Profile
    {
        public SupportRequestProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<SupportRequestDto, Agricultural.Domain.Entity.SupportRequest>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<SupportRequestQueryDto, Agricultural.Domain.Entity.SupportRequest>().ReverseMap();
        }
    }
}

using Agricultural.Application.DTOs.ConsultationRequest;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class ConsultationRequestProfile : Profile
    {
        public ConsultationRequestProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<ConsultationRequestDto, Agricultural.Domain.Entity.ConsultationRequest>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<ConsultationRequestQueryDto, Agricultural.Domain.Entity.ConsultationRequest>().ReverseMap();
        }
    }
}

using Agricultural.Application.DTOs.ConsultationRequestPic;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class ConsultationRequestPicProfile : Profile
    {
        public ConsultationRequestPicProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<ConsultationRequestPicDto, Agricultural.Domain.Entity.ConsultationRequestPic>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<ConsultationRequestPicQueryDto, Agricultural.Domain.Entity.ConsultationRequestPic>().ReverseMap();
        }
    }
}

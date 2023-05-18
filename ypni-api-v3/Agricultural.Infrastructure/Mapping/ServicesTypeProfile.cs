using Agricultural.Application.DTOs.ServicesType;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class ServicesTypeProfile : Profile
    {
        public ServicesTypeProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<ServicesTypeDto, Agricultural.Domain.Entity.ServicesType>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<ServicesTypeQueryDto, Agricultural.Domain.Entity.ServicesType>().ReverseMap();
        }
    }
}

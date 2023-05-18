using Agricultural.Application.DTOs.SP_Address;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class SP_AddressProfile : Profile
    {
        public SP_AddressProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<SP_AddressDto, Agricultural.Domain.Entity.SP_Address>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<SP_AddressQueryDto, Agricultural.Domain.Entity.SP_Address>().ReverseMap();
        }
    }
}

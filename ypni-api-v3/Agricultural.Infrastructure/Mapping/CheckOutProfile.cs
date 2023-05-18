using Agricultural.Application.DTOs.CheckOut;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class CheckOutProfile : Profile
    {
        public CheckOutProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<CheckOutDto, Agricultural.Domain.Entity.CheckOut>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<CheckOutQueryDto, Agricultural.Domain.Entity.CheckOut>().ReverseMap();
        }
    }
}

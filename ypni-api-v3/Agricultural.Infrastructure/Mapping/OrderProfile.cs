using Agricultural.Application.DTOs.Order;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<OrderDto, Agricultural.Domain.Entity.Order>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<OrderQueryDto, Agricultural.Domain.Entity.Order>().ReverseMap();
        }
    }
}

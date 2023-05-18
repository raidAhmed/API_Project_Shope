using Agricultural.Application.DTOs.Order;
using Agricultural.Application.DTOs.OrderDetails;
using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<OrderDetailsDto, Agricultural.Domain.Entity.OrderDetails>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<OrderDetailsQueryDto, Agricultural.Domain.Entity.OrderDetails>().ReverseMap();
        }
    }
}

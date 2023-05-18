using Agricultural.Application.DTOs.Cart;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<CartDto, Agricultural.Domain.Entity.Cart>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<CartQueryDto, Agricultural.Domain.Entity.Cart>().ReverseMap();
        }
    }
}

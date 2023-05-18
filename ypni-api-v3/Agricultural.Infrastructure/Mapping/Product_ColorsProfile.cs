using Agricultural.Application.DTOs.Product_Colors;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class Product_ColorsProfile : Profile
    {
        public Product_ColorsProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<Product_ColorsDto, Agricultural.Domain.Entity.Product_Colors>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<Product_ColorsQueryDto, Agricultural.Domain.Entity.Product_Colors>().ReverseMap();
        }
    }
}

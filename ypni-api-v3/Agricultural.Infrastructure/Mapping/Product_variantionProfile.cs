using Agricultural.Application.DTOs.Product_variantion;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class Product_variantionProfile : Profile
    {
        public Product_variantionProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<Product_variantionDto, Agricultural.Domain.Entity.Product_variantion>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<Product_variantionQueryDto, Agricultural.Domain.Entity.Product_variantion>().ReverseMap();
        }
    }
}

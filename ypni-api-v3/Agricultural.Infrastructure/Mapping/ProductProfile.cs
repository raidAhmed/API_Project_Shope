using Agricultural.Application.DTOs.Product;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<ProductDto, Agricultural.Domain.Entity.Product>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<ProductQueryDto, Agricultural.Domain.Entity.Product>().ReverseMap();
            CreateMap<productdtoADDapi, Agricultural.Domain.Entity.Product>().ReverseMap();
        }
    }
}

using Agricultural.Application.DTOs.Product_Attribute;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class Product_AttributeProfile : Profile
    {
        public Product_AttributeProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<Product_AttributeDto, Agricultural.Domain.Entity.Product_Attribute>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<Product_AttributeQueryDto, Agricultural.Domain.Entity.Product_Attribute>().ReverseMap();
        }
    }
}

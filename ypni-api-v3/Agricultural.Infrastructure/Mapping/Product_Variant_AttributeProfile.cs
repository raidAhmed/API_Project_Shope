using Agricultural.Application.DTOs.Product_Variant_Attribute;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class Product_Variant_AttributeProfile : Profile
    {
        public Product_Variant_AttributeProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<Product_Variant_AttributeDto, Agricultural.Domain.Entity.Product_Variant_Attribute>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<Product_Variant_AttributeQueryDto, Agricultural.Domain.Entity.Product_Variant_Attribute>().ReverseMap();
        }
    }
}

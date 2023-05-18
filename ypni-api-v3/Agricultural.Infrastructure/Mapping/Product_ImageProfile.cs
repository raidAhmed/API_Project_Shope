using Agricultural.Application.DTOs.Product_Image;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class Product_ImageProfile : Profile
    {
        public Product_ImageProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<Product_ImageDto, Agricultural.Domain.Entity.Product_Image>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<Product_ImageQueryDto, Agricultural.Domain.Entity.Product_Image>().ReverseMap();
        }
    }
}

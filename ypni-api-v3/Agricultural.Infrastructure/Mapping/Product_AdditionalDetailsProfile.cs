using Agricultural.Application.DTOs.Product_AdditionalDetails;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class Product_AdditionalDetailsProfile : Profile
    {
        public Product_AdditionalDetailsProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<Product_AdditionalDetailsDto, Agricultural.Domain.Entity.Product_AdditionalDetails>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<Product_AdditionalDetailsQueryDto, Agricultural.Domain.Entity.Product_AdditionalDetails>().ReverseMap();
        }
    }
}

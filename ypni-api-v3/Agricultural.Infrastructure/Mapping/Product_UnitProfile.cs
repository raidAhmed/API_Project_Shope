using Agricultural.Application.DTOs.Product_Unit;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class Product_UnitProfile : Profile
    {
        public Product_UnitProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<Product_UnitDto, Agricultural.Domain.Entity.Product_Unit>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<Product_UnitQueryDto, Agricultural.Domain.Entity.Product_Unit>().ReverseMap();
        }
    }
}

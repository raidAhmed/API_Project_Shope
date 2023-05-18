using Agricultural.Application.DTOs.Brand;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<BrandDto, Agricultural.Domain.Entity.Brand>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<BrandQueryDto, Agricultural.Domain.Entity.Brand>().ReverseMap();
        }
    }
}

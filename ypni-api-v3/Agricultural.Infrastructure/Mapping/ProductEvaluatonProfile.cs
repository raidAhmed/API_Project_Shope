using Agricultural.Application.DTOs.ProductEvaluaton;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class ProductEvaluatonProfile : Profile
    {
        public ProductEvaluatonProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<ProductEvaluatonDto, Agricultural.Domain.Entity.ProductEvaluaton>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<ProductEvaluatonQueryDto, Agricultural.Domain.Entity.ProductEvaluaton>().ReverseMap();
        }
    }
}

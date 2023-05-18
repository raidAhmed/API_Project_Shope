using Agricultural.Application.DTOs.BusinessCommercial;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class BusinessCommercialProfile : Profile
    {
        public BusinessCommercialProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<BusinessCommercialDto, Agricultural.Domain.Entity.BusinessCommercial>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<BusinessCommercialQueryDto, Agricultural.Domain.Entity.BusinessCommercial>().ReverseMap();
        }
    }
}

using Agricultural.Application.DTOs.Offer;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<OfferDto, Agricultural.Domain.Entity.Offer>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<OfferQueryDto, Agricultural.Domain.Entity.Offer>().ReverseMap();
        }
    }
}

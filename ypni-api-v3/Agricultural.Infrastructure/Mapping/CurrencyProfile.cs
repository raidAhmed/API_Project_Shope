using Agricultural.Application.DTOs.Currency;

using AutoMapper;
namespace Agricultural.Infrastructure.Mapping
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<CurrencyDto, Agricultural.Domain.Entity.Currency>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<CurrencyQueryDto, Agricultural.Domain.Entity.Currency>().ReverseMap();
        }
    }
}

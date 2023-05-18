using Agricultural.Application.DTOs.Banks;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class BanksProfile : Profile
    {
        public BanksProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<BanksDto, Agricultural.Domain.Entity.Banks>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<BanksQueryDto, Agricultural.Domain.Entity.Banks>().ReverseMap();
        }
    }
}

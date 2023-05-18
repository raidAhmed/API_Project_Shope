using Agricultural.Application.DTOs.OfficialParty;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class OfficialPartyProfile : Profile
    {
        public OfficialPartyProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<OfficialPartyDto, Agricultural.Domain.Entity.OfficialParty>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<OfficialPartyQueryDto, Agricultural.Domain.Entity.OfficialParty>().ReverseMap();
        }
    }
}

using Agricultural.Application.DTOs.ComplainantToParty;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class ComplainantToPartyProfile : Profile
    {
        public ComplainantToPartyProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<ComplainantToPartyDto, Agricultural.Domain.Entity.ComplainantToParty>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<ComplainantToPartyQueryDto, Agricultural.Domain.Entity.ComplainantToParty>().ReverseMap();
        }
    }
}

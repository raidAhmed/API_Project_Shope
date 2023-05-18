using Agricultural.Application.DTOs.SpecialSections;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class SpecialSectionsProfile : Profile
    {
        public SpecialSectionsProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<SpecialSectionsDto, Agricultural.Domain.Entity.SpecialSections>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<SpecialSectionsQueryDto, Agricultural.Domain.Entity.SpecialSections>().ReverseMap();
        }
    }
}

using Agricultural.Application.DTOs.AdditionalSections;
using Agricultural.Application.DTOs.SP_AdditionalSections;
using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class AdditionalSectionsProfile : Profile
    {
        public AdditionalSectionsProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<AdditionalSectionsDto, Agricultural.Domain.Entity.AdditionalSections>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<AdditionalSectionsQueryDto, Agricultural.Domain.Entity.AdditionalSections>().ReverseMap();
            CreateMap<SP_AdditionalSectionsDto, Agricultural.Domain.Entity.AdditionalSections>().ReverseMap();
        }
    }
}

using Agricultural.Application.DTOs.SP_AdditionalSections;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class SP_AdditionalSectionsProfile : Profile
    {
        public SP_AdditionalSectionsProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<SP_AdditionalSectionsDto, Agricultural.Domain.Entity.SP_AdditionalSections>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<SP_AdditionalSectionsQueryDto, Agricultural.Domain.Entity.SP_AdditionalSections>().ReverseMap();
        }
    }
}

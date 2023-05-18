using Agricultural.Application.DTOs.Directorate;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class DirectorateProfile : Profile
    {
        public DirectorateProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<DirectorateDto, Agricultural.Domain.Entity.Directorate>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<DirectorateQueryDto, Agricultural.Domain.Entity.Directorate>().ReverseMap();
        }
    }
}

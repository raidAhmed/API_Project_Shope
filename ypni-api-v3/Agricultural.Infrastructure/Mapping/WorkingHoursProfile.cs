using Agricultural.Application.DTOs.WorkingHours;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class WorkingHoursProfile : Profile
    {
        public WorkingHoursProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<WorkingHoursDto, Agricultural.Domain.Entity.WorkingHours>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<WorkingHoursQueryDto, Agricultural.Domain.Entity.WorkingHours>().ReverseMap();
        }
    }
}

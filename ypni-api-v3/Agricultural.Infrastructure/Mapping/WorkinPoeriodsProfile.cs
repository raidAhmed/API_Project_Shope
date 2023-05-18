using Agricultural.Application.DTOs.WorkinPoeriods;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class WorkinPoeriodsProfile : Profile
    {
        public WorkinPoeriodsProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<WorkinPoeriodsDto, Agricultural.Domain.Entity.WorkinPoeriods>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<WorkinPoeriodsQueryDto, Agricultural.Domain.Entity.WorkinPoeriods>().ReverseMap();
        }
    }
}

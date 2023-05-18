using Agricultural.Application.DTOs.ActivityType;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class ActivityTypeProfile : Profile
    {
        public ActivityTypeProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<ActivityTypeDto, Agricultural.Domain.Entity.ActivityType>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<ActivityTypeQueryDto, Agricultural.Domain.Entity.ActivityType>().ReverseMap();
        }
    }
}

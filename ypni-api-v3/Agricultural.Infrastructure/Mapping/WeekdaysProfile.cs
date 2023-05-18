using Agricultural.Application.DTOs.Weekdays;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class WeekdaysProfile : Profile
    {
        public WeekdaysProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<WeekdaysDto, Agricultural.Domain.Entity.Weekdays>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<WeekdaysQueryDto, Agricultural.Domain.Entity.Weekdays>().ReverseMap();
        }
    }
}

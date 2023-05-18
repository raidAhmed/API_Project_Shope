using Agricultural.Application.DTOs.News;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<NewsDto, Agricultural.Domain.Entity.News>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<NewsQueryDto, Agricultural.Domain.Entity.News>().ReverseMap();
        }
    }
}

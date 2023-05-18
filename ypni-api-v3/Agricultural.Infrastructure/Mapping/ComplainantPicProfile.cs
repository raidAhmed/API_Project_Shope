using Agricultural.Application.DTOs.ComplainantPic;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class ComplainantPicProfile : Profile
    {
        public ComplainantPicProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<ComplainantPicDto, Agricultural.Domain.Entity.ComplainantPic>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<ComplainantPicQueryDto, Agricultural.Domain.Entity.ComplainantPic>().ReverseMap();
        }
    }
}

using Agricultural.Application.DTOs.ComplainantToParty;
using Agricultural.Application.DTOs.User;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.Identity;
using AutoMapper;

namespace Agricultural.Infrastructure.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<UserCreateDto, User>().ForMember(x => x.PasswordHash, y => y.MapFrom(c => c.Password)).ReverseMap();
            CreateMap<UserCreateDto, UserQueryDto>().ReverseMap();
            CreateMap<UserUpdateDto, UserCreateDto>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<UserQueryDto, User>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<User, UserQueryDto>().ReverseMap();

            //Mapping UpdateDto To Entity
            CreateMap<UserUpdateDto, User>().ReverseMap();
            CreateMap<Complminttopartyapi, User>().ReverseMap();
            //Mapping QueryDto To Entity
            CreateMap<User, UserQueryDto>().ReverseMap();

            //Mapping UpdateDto To Entity
            CreateMap<UserUpdateDto, User>().ReverseMap();

        }
    }
}

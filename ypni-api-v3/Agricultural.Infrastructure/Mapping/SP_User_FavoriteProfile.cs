using Agricultural.Application.DTOs.SP_User_Favourites;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class SP_User_FavoriteProfile : Profile
    {
        public SP_User_FavoriteProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<SP_User_FavouritesDto, Agricultural.Domain.Entity.SP_User_Favourites>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<SP_User_FavouritesQueryDto, Agricultural.Domain.Entity.SP_User_Favourites>().ReverseMap();
        }
    }
}

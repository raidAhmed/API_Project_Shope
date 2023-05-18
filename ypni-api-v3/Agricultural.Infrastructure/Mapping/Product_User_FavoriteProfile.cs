using Agricultural.Application.DTOs.Product_User_Favourites;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class Product_User_FavoriteProfile : Profile
    {
        public Product_User_FavoriteProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<Product_User_FavouritesDto, Agricultural.Domain.Entity.Product_User_Favourites>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<Product_User_FavouritesQueryDto, Agricultural.Domain.Entity.Product_User_Favourites>().ReverseMap();
        }
    }
}

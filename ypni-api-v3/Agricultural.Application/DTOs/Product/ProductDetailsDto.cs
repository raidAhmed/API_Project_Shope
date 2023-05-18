using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agricultural.Application.DTOs.ServiceProvider;
using Agricultural.Application.DTOs.Product_Image;
using Agricultural.Application.DTOs.Product_Colors;
using Agricultural.Application.DTOs.Color;
using Agricultural.Application.DTOs.ProductEvaluaton;
using Agricultural.Application.DTOs.Product_User_Favourites;
using Agricultural.Application.DTOs.Cart;



namespace Agricultural.Application.DTOs.Product
{
    public class ProductDetailsDto
    {
       public ProductQueryDto product { get; set; }
        public List<Product_ImageQueryDto> ProductImages = new List<Product_ImageQueryDto>();
        public ProductEvaluatonQueryDto ProductEvaluaton { get; set; }
        public List<ProductEvaluatonQueryDto> ListProductEvaluaton  = new List<ProductEvaluatonQueryDto>(); 
        public List<ColorQueryDto> Colors = new List<ColorQueryDto>();  
        public CartDto Cart { get; set; }
        public Product_User_FavouritesQueryDto UserFavourites { get; set; }
        public List<Product_User_FavouritesQueryDto> ListUserFavourites = new List<Product_User_FavouritesQueryDto>();
        public int FavoCount { get; set; }
        public int EvaluCount { get; set; }
        public bool isFafo { get; set; }
        public decimal newPrice { get; set; }
        public ServiceProviderDto serviceProviderDto { get; set; } 

    }
}

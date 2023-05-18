using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Product_User_Favourites
{
    public class Product_User_FavouritesDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public String UserId { get; set; }
    }
}

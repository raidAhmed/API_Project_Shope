using Agricultural.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.ViewModels.Product_User_Favourites
{
    public class Product_User_FavouritesDDlLViewModels
    {
        public int Id { get; set; }//Id {} 
        public   productdtoADDapi product { get; set; }// ActivityName {lemgth(50)}
        //public bool Active { get; set; }
    }
}

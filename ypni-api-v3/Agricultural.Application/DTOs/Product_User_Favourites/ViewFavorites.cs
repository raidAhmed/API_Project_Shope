using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Agricultural.Application.DTOs.SP_User_Favourites;
using Agricultural.Application.DTOs.Product;
using Agricultural.Application.DTOs.ServiceProvider;

namespace Agricultural.Application.DTOs.Product_User_Favourites
{
    public class ViewFavorites
    {
        public List<ProductQueryDto> productDtos = new List<ProductQueryDto>();
        public List<ServiceProviderDto> serviceProviderDtos = new List<ServiceProviderDto>();   
        public List<productdtoADDapi> productdtoADDapis = new List<productdtoADDapi>(); 
    }
}

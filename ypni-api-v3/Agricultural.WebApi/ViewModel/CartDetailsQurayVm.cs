using Agricultural.Application.DTOs.CartDetails;
using Agricultural.Application.DTOs.OrderDetails;
using Agricultural.Application.DTOs.Product;

namespace Agricultural.WebApi.ViewModel
{
    public class ServerProviderVm
    {
        public string serverName { get; set; }
        public int serverProviderId { get; set; }
    }

    public class UserInformationVm
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Image { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        
      
    }
    public class CartDetailsQurayVm
    {
        public IEnumerable<CartDetailsQueryDto> cartDetailsQueryDtos { get; set; }
      public decimal total { get; set; }
      public decimal price { get; set; }
      public List<ServerProviderVm> serverProviderVm { get; set; }
        
        public List<ProductQueryDto> product { get; set; }
        public List<CartDetailsQueryDto> CartDetails { get; set; }



    }
    public class OrderDetailsQurayVm
    {
        public OrderVm orderVm { get; set; }
        public UserInformationVm? userInformationVm { get; set; }
      public List<ServerProviderVm> serverProviderVm { get; set; }
     
        public List<ProductQueryDto> product { get; set; }
        public List<OrderDetailsQueryDto> orderDetailsQueryDto { get; set; }

    }
}

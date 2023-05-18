using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.OrderDetails
{
    public class OrderDetailsDtoViewSEL
    {
        public int? ServiceProviderId { get; set; }
        public string ServiceProviderName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int orderId { get; set; }
        public string PhoneNumber { get; set; }
        public List<OrderDetailsDtoView> OrderDetails { set; get;}
    }
        public class OrderDetailsDtoView
    {
        public int Id { get; set; }
        public string Productname { get; set; }
        public string Productimage { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int State { get; set; }
        public bool Active { get; set; }
        public int ProductId { get; set; }
        public int? Product_variantionId { get; set; }
        public int? OrderId { get; set; }
        public int? ServiceProviderId { get; set; }
        public String? UserId { get; set; }
    }
}

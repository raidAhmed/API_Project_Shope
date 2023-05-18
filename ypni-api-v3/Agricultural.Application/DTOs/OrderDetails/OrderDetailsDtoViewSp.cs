using Agricultural.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.OrderDetails
{
    public class OrderDetailsDtoViewSELSp
    {
        public string Id { get; set; }
        public int orderId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderDetailsDtoViewSp> OrderDetails { set; get;}
    }
        public class OrderDetailsDtoViewSp
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

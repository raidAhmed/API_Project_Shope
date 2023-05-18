using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int State { get; set; }
        public bool Active { get; set; }
        public int ProductId { get; set; }
        public int? Product_variantionId { get; set; }
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public int? ServiceProviderId { get; set; }
        public Product Product { get; set; }
        public Product_variantion Product_Variantion { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }
        public OrderDetails()
        {
            Active = true;
            State = 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class CartDetails
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public bool State { get; set; }
        public bool Active { get; set; }
        public int ProductId { get; set; }
        public int? Product_variantionId { get; set; }
        public int CartId { get; set; }
        public string UserId { get; set; }
        public int? ServiceProviderId { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
        public Product_variantion Product_Variantion { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public User User { get; set; }
        public CartDetails()
        {
            Active= true;
            State= true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Product_variantion
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public String SKU { get; set; }
        public int? ProductId { get; set; }
        public bool Active { get; set; }

        public int qty { get; set; }
        public Product Product { get; set; }

        public List<CartDetails> CartDetails { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public Product_variantion()
        {
            Active = true;
        }

    }
}

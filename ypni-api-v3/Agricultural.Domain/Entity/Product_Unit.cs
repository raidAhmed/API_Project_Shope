using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Product_Unit
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public decimal Price { get; set; }
        public int qty { get; set; }
        public bool Active { get; set; }
        public Unit Unit { get; set; }
        public Product Prodact { get; set; }

        public Product_Unit()
        {
            Active = true;
        }

    }
}

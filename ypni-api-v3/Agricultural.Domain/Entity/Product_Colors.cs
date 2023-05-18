using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Product_Colors
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public bool Active { get; set; }
        public Product Product { get; set; }
        public Color Color { get; set; }

        public Product_Colors()
        {
            Active = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Product_Unit_Size
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public char ProductType { get; set; }
        public double ProductId { get; set; }
        public char State { get; set; }
        public Product Prodact { get; set; }

    }
}

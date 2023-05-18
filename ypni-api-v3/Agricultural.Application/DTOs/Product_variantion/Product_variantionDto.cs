using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Product_variantion
{
    public class Product_variantionDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string ColorNamee { get; set; }
        public int Coloridd { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public int ProductId { get; set; }
        public bool Active { get; set; }

        public int qty { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Product_Variant_Attribute
{
    public class Product_Variant_AttributeDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string value { get; set; }
        public int Product_AttributeId { get; set; }

    }
}

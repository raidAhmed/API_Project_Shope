using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Product_Variant_Attribute
    {
        public int Id { get; set; }
        public string value { get; set; }
        public int ProductId { get; set; }
        public int? Product_AttributeId { get; set; }
        public Product_Attribute Product_Attribute { get; set; }
        public Product Product { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Product_Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        // to Product_Variant_Attribute
        public List<Product_Variant_Attribute> product_Variant_Attributes { get; set; }
        public Product_Attribute()
        {
            Active = true;
        }
    }
}

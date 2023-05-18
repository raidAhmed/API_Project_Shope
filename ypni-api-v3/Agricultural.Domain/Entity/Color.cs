using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string code { get; set; }
        public bool Active { get; set; }

        // to Product_Colors
        public List<Product_Colors> Product_Colors { get; set; }


        public Color()
        {
            Active = true;
        }
    }
}

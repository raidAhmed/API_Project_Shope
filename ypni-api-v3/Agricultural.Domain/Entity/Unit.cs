using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int value { get; set; }
        public bool Active { get; set; }
        public Unit()
        {
            Active = true;
        }
        //to Product_Unit
        public List<Product_Unit> product_Units { get; set; }
    }
}

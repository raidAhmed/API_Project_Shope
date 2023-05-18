using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufactureCompanyId { get; set; }
        public string ImageUrl { get; set; }
        public bool Active { get; set; }
        public ManufactureCompany ManufactureCompany { get; set; }

        // to product 
        public List<Product> Products { get; set; }

        public Brand()
        {
            Active = true;
        }
    }
}

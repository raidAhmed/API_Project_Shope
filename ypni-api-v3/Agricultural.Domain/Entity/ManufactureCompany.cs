using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class ManufactureCompany
    {
        public int Id { get; set; } 

        public string Name { get; set; }
        public string CompanyInfo { get; set; }

        public string ImageUrl { get; set; } 
        public bool Active { get; set; }

        public List<Brand> Brands { get; set; }
        public ManufactureCompany()
        {
            Active = true;
        }
    }
}

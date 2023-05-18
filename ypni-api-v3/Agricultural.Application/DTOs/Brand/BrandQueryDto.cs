using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Brand
{
    public class BrandQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufactureCompanyId { get; set; }
        public string ManufactureCompanyName { get; set; }
        public string ImageUrl { get; set; }
        public bool Active { get; set; }
    }
}

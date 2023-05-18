using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ManufactureCompany
{
    public class ManufactureCompanyQueryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string CompanyInfo { get; set; }

        public string ImageUrl { get; set; }
        public bool Active { get; set; }

        public IFormFile File { get; set; }
    }
}

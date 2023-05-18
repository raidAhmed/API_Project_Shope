using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Brand
{
    public class BrandDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل أسم العلامة التجارية  ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "  أختار أسم القسم الرئيسي    ")]     
        public string ImageUrl { get; set; }
        public int ManufactureCompanyId { get; set; }
        public bool Active { get; set; }
       // public IFormFile File { get; set; }
    }
}

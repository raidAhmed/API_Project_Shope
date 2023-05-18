using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Banks
{
    public class BanksDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل أسم البنك  ")]
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public bool Active { get; set; }
        public IFormFile? File { get; set; }

    }
}

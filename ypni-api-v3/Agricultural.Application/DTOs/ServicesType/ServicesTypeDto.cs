using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ServicesType
{
    public class ServicesTypeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل أسم النشاط  ")]
        public string Name { get; set; }
        public string? UserId { get; set; } = null;
        public bool Active { get; set; }

    }
}

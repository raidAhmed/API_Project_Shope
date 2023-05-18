using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Color
{
    public class ColorDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل أسم اللون  ")]
        public string Name { get; set; }
        [Required(ErrorMessage = " أدحل الكود اللون  ")]
        public string code { get; set; }
        public bool Active { get; set; }
    }
    public class ColorDtoseselectlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelect { get; set; }
    }
    }

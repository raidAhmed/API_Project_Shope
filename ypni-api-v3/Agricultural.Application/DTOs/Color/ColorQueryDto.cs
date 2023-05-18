using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Color
{
    public class ColorQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string code { get; set; }
        public bool Active { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Unit
{
    public class UnitQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int value { get; set; }
        public bool Active { get; set; }
    }
}

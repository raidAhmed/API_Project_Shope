using Agricultural.Application.DTOs.Directorate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.City
{
    public class CityQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Active { get; set; }
        public List<DirectorateQueryDto> directorates { get; set; }
    }
}

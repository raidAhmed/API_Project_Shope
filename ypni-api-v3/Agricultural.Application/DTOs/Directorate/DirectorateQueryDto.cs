using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Directorate
{
    public class DirectorateQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public int? CityId { get; set; }
        public bool Active { get; set; }
      
        }
}

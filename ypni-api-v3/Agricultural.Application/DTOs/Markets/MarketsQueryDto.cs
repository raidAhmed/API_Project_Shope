using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Markets
{
    public class MarketsQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? DescriptionAddress { get; set; }
        public int? CityId { get; set; }
        public int? DirectorateId { get; set; }
        public bool Active { get; set; }
    }

}


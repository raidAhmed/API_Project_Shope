using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Farmer
{
    public class FarmerQueryDto
    {
        public int Id { get; set; }
        public string EarthLength { get; set; }
        public string EarthInfo { get; set; }
        public string EarthWidth { get; set; }
        public int ServiceProviderId { get; set; }
        public bool Active { get; set; }
    }
}

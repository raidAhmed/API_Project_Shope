using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.SP_ProFeatures
{
    public class SP_ProFeaturesQueryDto
    {
        public int Id { get; set; }
        public int? ServiceProviderId { get; set; }
        public int? ProFeaturesId { get; set; }
        public bool Active { get; set; }
    }
}

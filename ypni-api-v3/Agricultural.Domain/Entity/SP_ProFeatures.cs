using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class SP_ProFeatures
    {
        public int Id { get; set; }
        public int? ServiceProviderId { get; set; }
        public int? ProFeaturesId { get; set; }
        public bool Active { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public ProFeatures ProFeatures { get; set; }
    }
}

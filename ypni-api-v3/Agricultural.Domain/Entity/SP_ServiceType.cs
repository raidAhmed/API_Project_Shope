using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class SP_ServiceType
    {
        public int Id { get; set; }
        public int? ServiceProviderId { get; set; }
        public int? ServiceTypeId { get; set; }

        public ServiceProvider ServiceProvider { get; set; }
        public ServicesType ServiceType { get; set; }
    }
}

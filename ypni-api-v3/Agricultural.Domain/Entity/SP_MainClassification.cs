using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class SP_MainClassification
    {
        public int Id { get; set; }
        public int? MainClassificationId { get; set; }
        public int? ServiceProviderId { get; set; }
        public bool Active { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public MainClassification MainClassification { get; set; }

        public SP_MainClassification()
        {
            Active = true;
        }
    }
}

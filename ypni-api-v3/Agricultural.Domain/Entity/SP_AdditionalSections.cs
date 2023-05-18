using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class SP_AdditionalSections
    {
        public int Id { get; set; }
        public int? AdditionalSectionsId { get; set; }
        public int? ServiceProviderId { get; set; }
        public bool Active { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public AdditionalSections AdditionalSections { get; set; }
      
        public SP_AdditionalSections()
        {
            Active = true;
        }

    }
}

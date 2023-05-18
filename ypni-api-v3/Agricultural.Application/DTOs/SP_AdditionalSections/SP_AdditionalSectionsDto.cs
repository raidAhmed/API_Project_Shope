using Agricultural.Application.DTOs.AdditionalSections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.SP_AdditionalSections
{
    public class SP_AdditionalSectionsDto
    {
        public int Id { get; set; }
        public int? AdditionalSectionsId { get; set; }
        public int? MainClassificationId { get; set; }
        public String AdditionalSectionsName { get; set; } = null;
        public bool Active { get; set; }
        public AdditionalSectionsDto AdditionalSections { get; set; }
        public List<int> AdditionalSectionsIdd { get; set; }    
        public List<Listaddtiotionalsection> listaddtiotionalsection { get; set; }
        public int? ServiceProviderId { get; set; }

        public int ParnetSectionId { get; set; }
    }
    public class SP_AdditionalSectionsDtoApi
    {
        public int? AdditionalSectionsId { get; set; }
        public int? ServiceProviderId { get; set; }

    }
    public class Listaddtiotionalsection
    {
        public int AdditionalSectionsIId { get; set; }
    }
}

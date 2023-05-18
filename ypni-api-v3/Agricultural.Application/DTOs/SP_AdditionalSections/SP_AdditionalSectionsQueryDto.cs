using Agricultural.Application.DTOs.AdditionalSections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.SP_AdditionalSections
{
    public class SP_AdditionalSectionsQueryDto
    {
        public int Id { get; set; }
        public int? AdditionalSectionsId { get; set; }
        public int? MainClassificationId { get; set; }
        public int? ParnetSectionId { get; set; }
        public String AdditionalSectionsName { get; set; }
        public List<SP_AdditionalSectionsQueryDto> AdditionalSections { get; set; }
        public int? ServiceProviderId { get; set; }
        public bool Active { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.SpecialSections
{
    public class SpecialSectionsQueryDto
    {
        public int Id { get; set; }
        public string SpecialSectionName { get; set; }
        public string ImageUrl { get; set; }
        public int? MainClassificationId { get; set; }
        public String? MainClassificationName { get; set; }
        public int? AdditionalSectionsId { get; set; }
        public String? AdditionalSectionsName { get; set; }
        public int? ParnetSectionId { get; set; }
        public String? ParnetSectionName { get; set; }
        public int Rank { get; set; }
        public int? ServiceProviderId { get; set; }
        public String? ServiceProviderName { get; set; }
        public bool Active { get; set; }



    }
}

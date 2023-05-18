using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.AdditionalSections
{
    public class AdditionalSectionsQueryDto
    {
        public int Id { get; set; }
        public String AdditionalSectionsName { get; set; }
        public String MainClassificationName { get; set; }
        public string ImageUrl { get; set; }
        public string MainClassificationImageUrl { get; set; }
        public int? Rank { get; set; }
        public int? ParnetSectionId { get; set; }
        public int? MainClassificationId { get; set; }
        public bool Active { get; set; }

    }
}

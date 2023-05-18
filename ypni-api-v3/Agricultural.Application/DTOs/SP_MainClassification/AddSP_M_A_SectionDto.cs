using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.SP_MainClassification
{
    public class AddSP_M_A_SectionDto
    {
        public int Id { get; set; }
        public int MainClassificationId { get; set; }
        public int AdditionalSectionsId { get; set; }
        
        public String MainClassificationName { get; set; }
        public String AdditionalSectionName { get; set; }
        public int ServiceProviderId { get; set; }
    }
}

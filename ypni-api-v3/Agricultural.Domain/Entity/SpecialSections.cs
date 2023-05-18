using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class SpecialSections
    {
        public int Id { get; set; } 
        public string SpecialSectionName { get; set; }
        public string ImageUrl { get; set; }
        public int? MainClassificationId { get; set; }
        public int? AdditionalSectionsId { get; set; }
        public int? ParnetSectionId { get; set; }
        public int Rank { get; set; }
       // public int? BusinessCommercialId { get; set; }
        public MainClassification MainClassification { get; set; }
        public AdditionalSections AdditionalSections { get; set; }
       // public BusinessCommercial BusinessCommercial { get; set; }
        // to product 
        public List<Product> Products { get; set; }
        
        public int? ServiceProviderId { get; set; }
        public bool Active { get; set; }
        public ServiceProvider ServiceProvider { get; set; }

        public SpecialSections ToSpecialSections { get; set; }
        public List<SpecialSections> FormSpecialSectionslist { get; set; }

        public SpecialSections()
        {
            Active = true;
        }

        
    }

}

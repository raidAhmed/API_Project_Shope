using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class AdditionalSections
    {
        public int Id { get; set; }// id {primary key}
        public String AdditionalSectionsName { get; set; }// ActivityName {lemgth(50)}
        public int Rank { get; set; }
        public string ImageUrl { get; set; }
        public int? ParnetSectionId { get; set; }
        public int? MainClassificationId { get; set; }
        public MainClassification MainClassification { get; set; }


        public AdditionalSections additionalSectionParent { get; set; }
        public List<AdditionalSections> additionalSectionChild { get; set; }

        // to product 
        public List<Product> Products { get; set; }


        public bool Active { get; set; }

        public List<SpecialSections> SpecialSections { get; set; }

        public List<SP_AdditionalSections> SP_AdditionalSections { get; set; }
        public AdditionalSections()
        {
            Active = true;
        }

    }
}

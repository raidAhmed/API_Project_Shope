using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class MainClassification
    {

        public int Id { get; set; }
        public string MainClassificationName { get; set; }
        public int? ActivityTypeId { get; set; }
        public string ImageUrl { get; set; }
        public ActivityType ActivityType { get; set; }

        public List<AdditionalSections> AdditionalSections { get; set; }

        // to product 
        public List<Product> Products { get; set; }


        public bool Active { get; set; }
        public List<SpecialSections> SpecialSections { get; set; }
        public List<SP_MainClassification> SP_MainClassifications { get; set; }
        public MainClassification()
        {
            Active = true;
        }

    }
}

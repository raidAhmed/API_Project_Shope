using Agricultural.Domain.Entity.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class ServiceProvider : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string TradeName { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? NatId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        // from user
        public string UserId { get; set; }
        // from activity type
        public int ActivityTypeId { get; set; }
        public int ViewPlace { get; set; }
        public bool Active { get; set; }
        public int ServiceTypeId { get; set; }
        public ActivityType ActivityType { get; set; }

        public User User { get; set; }

        // to product 
        public List<Product> Products { get; set; }
        // to ProviderEvaluation
        public List<ProviderEvaluation> providerEvaluations { get; set; }

        // to SP_User_Favourites
        public List<SP_User_Favourites> sP_User_Favourites { get; set; }

     //   public List<SP_Address> SP_Address { get; set; }
        public List<OfficialParty> OfficialPartys { get; set; }
        public List<BusinessCommercial> BusinessCommercials { get; set; }
        public List<Farmer> Farmers { get; set; }
        public List<SP_MainClassification> SP_MainClassifications { get; set; }
        public List<ConsultationRequest> ConsultationRequests { get; set; }

        public List<SP_ProFeatures> SP_ProFeatures { get; set; }
        public List<Offer> Offers { get; set; }

        public ServicesType ServiceType { get; set; }

        public List<SpecialSections> SpecialSections { get; set; }
        public List<SP_AdditionalSections> SP_AdditionalSections { get; set; }
        public List<Slider> sliders { get; set; }
        public List<Cart> Carts { get; set; }
        public List<CartDetails> CartDetails { get; set; }  
        public List<Order> Orders { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public List<WorkingHours> WorkingHours { get; set; }
        public ServiceProvider()
        {
            Active = false;
        }
    }
}

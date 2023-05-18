using Agricultural.Domain.Entity.Base;
namespace Agricultural.Domain.Entity
{
    public class ActivityType: AuditableEntity,IBaseEntity<int>
    {
        public int Id { get; set; }//Id {}
        public String ActivityName { get; set; }// ActivityName {lemgth(50)}
        public bool Active { get; set; }

        public List<MainClassification> MainClassifications { get; set; }

        // to product 
        public List<Product> Products { get; set; }
        public ActivityType()
        {
            Active = true;
        }
        }


}

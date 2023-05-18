using Agricultural.Domain.Entity.Base;
namespace Agricultural.Domain.Entity
{
    public class Delivery_Histories : AuditableEntity,IBaseEntity<int>
    {
        public int Id { get; set; }//Id {}
        public DateTime DateTim { get; set; }
        public string Location { get; set; }
        public int? OrderId { get; set; }//Id {}
        public Order Order { get; set; }

   
        }


}

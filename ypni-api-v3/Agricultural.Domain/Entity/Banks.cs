using Agricultural.Domain.Entity.Base;
namespace Agricultural.Domain.Entity
{
    public class Banks : AuditableEntity,IBaseEntity<int>
    {
        public int Id { get; set; }//Id {}
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public bool Active { get; set; }

        public List<User_Bank> User_Bank { get; set; }

        // to product 
        public Banks()
        {
            Active = true;
        }
        }


}

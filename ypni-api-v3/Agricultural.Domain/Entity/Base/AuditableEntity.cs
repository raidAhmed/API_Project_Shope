namespace Agricultural.Domain.Entity.Base
{
    public abstract class AuditableEntity: ISoftDelete
    {
        public int CreatedByUser { get; set; }
        public DateTime CreatedAt { get; set; } 
        public int? LastModifiedBy{ get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
    public interface ISoftDelete
    {
         bool IsDeleted { get; set; }
         String? DeletedBy { get; set; }
         DateTime? DeletedAt { get; set; } 
      

    }
}

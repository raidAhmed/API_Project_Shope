using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class MainClassificationConfiguration : IEntityTypeConfiguration<MainClassification>
    {
        
        public void Configure(EntityTypeBuilder<MainClassification> builder)
        {
            builder.ToTable("MainClassification", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_MainClassification").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.MainClassificationName).HasColumnName(@"MainClassificationName").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
             builder.Property(x => x.ImageUrl).HasColumnName(@"ImageUrl").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.ActivityTypeId).HasColumnName(@"ActivityTypeId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");

            // Foreign keys
            builder.HasOne(a => a.ActivityType).WithMany(b => b.MainClassifications).HasForeignKey(c => c.ActivityTypeId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MainClassifications_ActivityType");

        }
    }
}

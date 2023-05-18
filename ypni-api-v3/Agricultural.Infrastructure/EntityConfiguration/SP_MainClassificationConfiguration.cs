using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class SP_MainClassificationConfiguration : IEntityTypeConfiguration<SP_MainClassification>
    {
        
        public void Configure(EntityTypeBuilder<SP_MainClassification> builder)
        {
            builder.ToTable("SP_MainClassification", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SP_MainClassification").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.MainClassificationId).HasColumnName(@"MainClassificationId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ServiceProviderId).HasColumnName(@"ServiceProviderId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");
            // Foreign keys
            builder.HasOne(a => a.MainClassification).WithMany(b => b.SP_MainClassifications).IsRequired(false).HasForeignKey(c => c.MainClassificationId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SP_MainClassificationsm_MainClassification");
            builder.HasOne(a => a.ServiceProvider).WithMany(b => b.SP_MainClassifications).IsRequired(false).HasForeignKey(c => c.ServiceProviderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SP_MainClassificationsm_ServiceProvider");
        
    }
    }
}

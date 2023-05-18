using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class SP_ProFeaturesConfiguration : IEntityTypeConfiguration<SP_ProFeatures>
    {
        
        public void Configure(EntityTypeBuilder<SP_ProFeatures> builder)
        {
            builder.ToTable("SP_ProFeatures", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SP_ProFeatures").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ServiceProviderId).HasColumnName(@"ServiceProviderId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ProFeaturesId).HasColumnName(@"ProFeaturesId").HasColumnType("int").IsRequired(false);
          
            // Foreign keys
            builder.HasOne(a => a.ServiceProvider).WithMany(b => b.SP_ProFeatures).IsRequired(false).HasForeignKey(c => c.ServiceProviderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SP_ProFeatures_ServiceProvider");
            builder.HasOne(a => a.ProFeatures).WithMany(b => b.SP_ProFeatures).IsRequired(false).HasForeignKey(c => c.ProFeaturesId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SP_ProFeatures_ProFeature");
        
    }
    }
}

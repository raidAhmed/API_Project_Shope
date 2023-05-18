using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class SP_AdditionalSectionsConfiguration : IEntityTypeConfiguration<SP_AdditionalSections>
    {
        
        public void Configure(EntityTypeBuilder<SP_AdditionalSections> builder)
        {
            builder.ToTable("SP_AdditionalSections", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SP_AdditionalSections").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.AdditionalSectionsId).HasColumnName(@"AdditionalSectionsId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ServiceProviderId).HasColumnName(@"ServiceProviderId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");
            // Foreign keys
            builder.HasOne(a => a.AdditionalSections).WithMany(b => b.SP_AdditionalSections).IsRequired(false).HasForeignKey(c => c.AdditionalSectionsId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SP_AdditionalSections_AdditionalSections");
            builder.HasOne(a => a.ServiceProvider).WithMany(b => b.SP_AdditionalSections).IsRequired(false).HasForeignKey(c => c.ServiceProviderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SP_AdditionalSections_ServiceProvider");
        
    }
    }
}

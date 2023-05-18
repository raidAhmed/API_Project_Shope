using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class AdditionalSectionsConfiguration : IEntityTypeConfiguration<AdditionalSections>
    {
        
        public void Configure(EntityTypeBuilder<AdditionalSections> builder)
        {
            builder.ToTable("AdditionalSections", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_AdditionalSections").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.AdditionalSectionsName).HasColumnName(@"AdditionalSectionsName").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl).HasColumnName(@"ImageUrl").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.MainClassificationId).HasColumnName(@"MainClassificationId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");

            // Foreign keysAdditionalSections
            builder.HasOne(a => a.MainClassification).WithMany(b => b.AdditionalSections).HasForeignKey(c => c.MainClassificationId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AdditionalSections_MainClassification");
            builder.HasOne(a => a.additionalSectionParent).WithMany(b => b.additionalSectionChild).HasForeignKey(c => c.ParnetSectionId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

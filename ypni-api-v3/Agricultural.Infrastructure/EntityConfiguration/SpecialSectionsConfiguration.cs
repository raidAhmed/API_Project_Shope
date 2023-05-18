using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class SpecialSectionsConfiguration : IEntityTypeConfiguration<SpecialSections>
    {
        
        public void Configure(EntityTypeBuilder<SpecialSections> builder)
        {
            builder.ToTable("SpecialSections", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SpecialSections").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.SpecialSectionName).HasColumnName(@"SpecialSectionName").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl).HasColumnName(@"ImageUrl").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.MainClassificationId).HasColumnName(@"MainClassificationId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.AdditionalSectionsId).HasColumnName(@"AdditionalSectionsId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");

            // Foreign keys
            builder.HasOne(a => a.MainClassification).WithMany(b => b.SpecialSections).HasForeignKey(c => c.MainClassificationId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SpecialSections_MainClassification");
            builder.HasOne(a => a.AdditionalSections).WithMany(b => b.SpecialSections).HasForeignKey(c => c.AdditionalSectionsId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SpecialSections_AdditionalSections");
            builder.HasOne(a => a.ServiceProvider).WithMany(b => b.SpecialSections).HasForeignKey(c => c.ServiceProviderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SpecialSections_ServiceProvider");
            builder.HasOne(a => a.ToSpecialSections).WithMany(b => b.FormSpecialSectionslist).HasForeignKey(c => c.ParnetSectionId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SpecialSections_SpecialSections");

        }
    }
}

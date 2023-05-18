using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class FarmerConfiguration : IEntityTypeConfiguration<Farmer>
    {

        public void Configure(EntityTypeBuilder<Farmer> builder)
        {
            builder.ToTable("Farmer", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Farmer").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.EarthLength).HasColumnName(@"EarthLength").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.EarthInfo).HasColumnName(@"EarthInfo").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.EarthWidth).HasColumnName(@"EarthWidth").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ServiceProviderId).HasColumnName(@"ServiceProviderId").HasColumnType("int").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.ServiceProvider).WithMany(b => b.Farmers).HasForeignKey(c => c.ServiceProviderId).OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false).HasConstraintName("FK_Farmers_ServiceProvider");

        }
    }
}

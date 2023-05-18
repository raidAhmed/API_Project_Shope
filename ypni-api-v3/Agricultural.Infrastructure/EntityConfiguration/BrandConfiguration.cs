using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Brand").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl).HasColumnName(@"ImageUrl").HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");


            builder.HasOne(x=>x.ManufactureCompany).WithMany(f=>f.Brands).HasForeignKey(x=>x.ManufactureCompanyId).IsRequired().OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Brand_ManufactureCompany");
        }
    }
}

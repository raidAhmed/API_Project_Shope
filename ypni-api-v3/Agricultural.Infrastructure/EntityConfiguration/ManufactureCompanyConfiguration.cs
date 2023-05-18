using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    public class ManufactureCompanyConfiguration : IEntityTypeConfiguration<ManufactureCompany>
    {
        public void Configure(EntityTypeBuilder<ManufactureCompany> builder)
        {
            builder.ToTable("ManufactureCompany", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ManufactureCompany").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl).HasColumnName(@"ImageUrl").HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit").IsRequired();
        }
    }
}

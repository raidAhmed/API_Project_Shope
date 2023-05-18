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
    public class ProFeaturesConfiguration : IEntityTypeConfiguration<ProFeatures>
    {
        public void Configure(EntityTypeBuilder<ProFeatures> builder)
        {
            builder.ToTable("ProFeatures", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ProFeatures").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
        }
    }
}

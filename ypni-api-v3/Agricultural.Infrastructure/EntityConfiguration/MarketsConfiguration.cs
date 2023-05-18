using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class MarketsConfiguration : IEntityTypeConfiguration<Markets>
    {
        
        public void Configure(EntityTypeBuilder<Markets> builder)
        {
            builder.ToTable("Markets", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Markets").IsClustered();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl).HasColumnName(@"ImageUrl").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.DescriptionAddress).HasColumnName(@"DescriptionAddress").HasColumnType("nvarchar(200)").IsRequired(false);
            builder.Property(x => x.CityId).HasColumnName(@"CityId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.DirectorateId).HasColumnName(@"DirectorateId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit").IsRequired();

        }
    }
}

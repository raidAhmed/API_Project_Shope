using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class SliderImagesConfiguration : IEntityTypeConfiguration<SliderImages>
    {
        
        public void Configure(EntityTypeBuilder<SliderImages> builder)
        {
            builder.ToTable("SliderImages", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SliderImages").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Details).HasColumnName(@"Details").HasColumnType("nvarchar(255)").HasMaxLength(255);
            builder.Property(x => x.ImageUrl).HasColumnName(@"ImageUrl").HasColumnType("nvarchar(200)").HasMaxLength(200);
            builder.Property(x => x.Url).HasColumnName(@"Url").HasColumnType("nvarchar(200)").HasMaxLength(200);
            builder.Property(x => x.SliderId).HasColumnName(@"SliderId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");

            builder.HasOne(x => x.Slider).WithMany(x => x.SliderImages).HasForeignKey(x => x.SliderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SliderImage_Slider");
        }
    }
}

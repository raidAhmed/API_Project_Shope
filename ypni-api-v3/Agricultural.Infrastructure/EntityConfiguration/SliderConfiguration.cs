using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.ToTable("Slider", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Slider").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Details).HasColumnName(@"Details").HasColumnType("nvarchar(255)").HasMaxLength(255);
            builder.Property(x => x.Type).HasColumnName(@"Type").HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.StartDate).HasColumnName(@"StartDate").HasColumnType("DateTime").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.EndDate).HasColumnName(@"EndDate").HasColumnType("DateTime");
            builder.Property(x => x.ServiceProviderId).HasColumnName(@"ServiceProviderId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");

            builder.HasOne(x => x.ServiceProvider).WithMany(x => x.sliders).HasForeignKey(x => x.ServiceProviderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Slider_ServiceProvider");
        }
    }
}

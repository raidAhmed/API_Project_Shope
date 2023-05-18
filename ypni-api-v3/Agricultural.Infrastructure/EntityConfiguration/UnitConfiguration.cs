using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Unit", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Unit").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.value).HasColumnName(@"value").HasColumnType("int").IsRequired();
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit").IsRequired();
        }
    }
}

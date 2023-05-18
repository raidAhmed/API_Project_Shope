using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class DirectorateConfiguration : IEntityTypeConfiguration<Directorate>
    {
        
        public void Configure(EntityTypeBuilder<Directorate> builder)
        {
            builder.ToTable("Directorate", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Directorate").IsClustered();
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.CityId).HasColumnName(@"CityId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit").IsRequired();
            builder.HasOne(a => a.City).WithMany(b => b.Directorates).HasForeignKey(c => c.CityId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Directorates_City");
        }
    }
}

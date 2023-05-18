using Agricultural.Domain.Entity;
using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class BanksConfiguration : IEntityTypeConfiguration<Banks>
    {
        
        public void Configure(EntityTypeBuilder<Banks> builder)
        {
            builder.ToTable("Banks", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Banks").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl).HasColumnName(@"ImageUrl").HasColumnType("nvarchar(100)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");
           
   
        }
    }
}

using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class ServiceTypeConfiguration : IEntityTypeConfiguration<ServicesType>
    {
        
        public void Configure(EntityTypeBuilder<ServicesType> builder)
        {
            builder.ToTable("ServicesType", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ServicesType").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");
            builder.HasData(
             new ServicesType
             {
                 Id = 1,
                 Name = "خدمة",
             },
             new ServicesType
             {
                 Id = 2,
                 Name = "تاجر"
             }
             );
           
        }
    }
}

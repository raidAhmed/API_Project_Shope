using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class ActivityTypeConfiguration : IEntityTypeConfiguration<ActivityType>
    {
        
        public void Configure(EntityTypeBuilder<ActivityType> builder)
        {
            builder.ToTable("ActivityType", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ActivityType").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ActivityName).HasColumnName(@"ActivityName").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");
            builder.HasData(
                  new ActivityType
                  {

                      Id = 1,
                      ActivityName = "خدمي",
                  },
               new ActivityType
               {
                   Id = 2,
                   ActivityName = "تجاري",
               });
        }
    }
}

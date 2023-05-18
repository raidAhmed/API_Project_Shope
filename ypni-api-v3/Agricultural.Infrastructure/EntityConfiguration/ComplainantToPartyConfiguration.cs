using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class ComplainantToPartyConfiguration : IEntityTypeConfiguration<ComplainantToParty>
    {

        public void Configure(EntityTypeBuilder<ComplainantToParty> builder)
        {
            builder.ToTable("ComplainantToParty", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ComplainantToParty").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ServiceType).HasColumnName(@"ServiceType").HasColumnType("int").HasDefaultValue(0);
            builder.Property(x => x.Topic).HasColumnName(@"Topic").HasColumnType("nvarchar(100)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.TypeofMesseage).HasColumnName(@"TypeofMesseage").HasColumnType("nvarchar(100)").IsRequired(false);

            builder.Property(x => x.SenderId).HasColumnName(@"SenderId").HasColumnType("nvarchar(100)").IsRequired(false);
            builder.Property(x => x.ReciverId).HasColumnName(@"ReciverId").HasColumnType("nvarchar(100)").IsRequired(false);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");
            // Foreign keys

        }
    }
}

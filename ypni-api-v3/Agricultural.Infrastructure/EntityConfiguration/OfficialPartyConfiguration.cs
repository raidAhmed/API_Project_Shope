using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class OfficialPartyConfiguration : IEntityTypeConfiguration<OfficialParty>
    {
        
        public void Configure(EntityTypeBuilder<OfficialParty> builder)
        {
            builder.ToTable("OfficialParty", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_OfficialParty").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.OrganisationType).HasColumnName(@"OrganisationType").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ServiceProviderId).HasColumnName(@"ServiceProviderId").HasColumnType("int").IsRequired(false);
         
            // Foreign keys
            builder.HasOne(a => a.ServiceProvider).WithMany(b => b.OfficialPartys).HasForeignKey(c => c.ServiceProviderId).OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false).HasConstraintName("FK_OfficialPartys_ServiceProvider");

        }
    }
}

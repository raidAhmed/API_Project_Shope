using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class SupportRequestConfiguration : IEntityTypeConfiguration<SupportRequest>
    {
        
        public void Configure(EntityTypeBuilder<SupportRequest> builder)
        {
            builder.ToTable("SupportRequest", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SupportRequest").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Topic).HasColumnName(@"Topic").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl).HasColumnName(@"ImageUrl").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(250)").HasMaxLength(250);
            builder.Property(x => x.FarmerId).HasColumnName(@"FarmerId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.OfficialPartyId).HasColumnName(@"OfficialPartyId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");
            // Foreign keys
            builder.HasOne(a => a.Farmer).WithMany(b => b.SupportRequests).IsRequired(false).HasForeignKey(c => c.FarmerId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SupportRequests_Farmer");
            builder.HasOne(a => a.OfficialParty).WithMany(b => b.SupportRequests).IsRequired(false).HasForeignKey(c => c.OfficialPartyId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SP_SupportRequests_OfficialParty");

        }
    }
}

using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class ConsultationRequestConfiguration : IEntityTypeConfiguration<ConsultationRequest>
    {

        public void Configure(EntityTypeBuilder<ConsultationRequest> builder)
        {
            builder.ToTable("ConsultationRequest", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ConsultationRequestt").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Topic).HasColumnName(@"Topic").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(250)").HasMaxLength(250);
            builder.Property(x => x.FarmerId).HasColumnName(@"FarmerId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ServiceProviderId).HasColumnName(@"ServiceProviderId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");
            // Foreign keys
            builder.HasOne(a => a.Farmer).WithMany(b => b.ConsultationRequests).HasForeignKey(c => c.FarmerId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ConsultationRequest_Farmer");
            builder.HasOne(a => a.ServiceProvider).WithMany(b => b.ConsultationRequests).HasForeignKey(c => c.ServiceProviderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ConsultationRequest_ServiceProvider");

        }
    }
}

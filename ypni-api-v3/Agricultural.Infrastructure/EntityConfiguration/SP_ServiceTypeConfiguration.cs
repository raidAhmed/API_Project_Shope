using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class SP_ServiceTypeConfiguration : IEntityTypeConfiguration<SP_ServiceType>
    {
        
        public void Configure(EntityTypeBuilder<SP_ServiceType> builder)
        {
            //builder.ToTable("SP_ServiceType", "dbo");
            //builder.HasKey(x => x.Id).HasName("PK_SP_ServiceType").IsClustered();

            //builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            //builder.Property(x => x.ServiceProviderId).HasColumnName(@"ServiceProviderId").HasColumnType("int").IsRequired(false);
            //builder.Property(x => x.ServiceTypeId).HasColumnName(@"ServiceTypeId").HasColumnType("int").IsRequired(false);
          
            //// Foreign keys
            //builder.HasOne(a => a.ServiceProvider).WithMany(b => b.sP_ServiceTypes).IsRequired(false).HasForeignKey(c => c.ServiceProviderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SP_ServiceType_ServiceProvider");
            //builder.HasOne(a => a.ServiceType).WithMany(b => b.sP_ServiceTypes).IsRequired(false).HasForeignKey(c => c.ServiceTypeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SP_ServiceType_ServiceType");
        
    }
    }
}

using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class BusinessCommercialConfiguration : IEntityTypeConfiguration<BusinessCommercial>
    {
        
        public void Configure(EntityTypeBuilder<BusinessCommercial> builder)
        {
            builder.ToTable("BusinessCommercial", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_BusinessCommercial").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.BankAccount).HasColumnName(@"BankAccount").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.TradeRecord).HasColumnName(@"TradeRecord").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ServiceProviderId).HasColumnName(@"ServiceProviderId").HasColumnType("int").IsRequired(false);
            // Foreign keys
            builder.HasOne(a => a.ServiceProvider).WithMany(b => b.BusinessCommercials).HasForeignKey(c => c.ServiceProviderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_BusinessCommercials_ServiceProvider");

        }
    }
}

using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceProvider>
    {
        public void Configure(EntityTypeBuilder<ServiceProvider> builder)
        {
            builder.ToTable("ServiceProvider", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ServiceProvider").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.TradeName).HasColumnName(@"TradeName").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Logo).HasColumnName(@"Logo").HasColumnType("nvarchar(250)").IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.Email).HasColumnName(@"Email").HasColumnType("nvarchar(250)").IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.PhoneNumber).HasColumnName(@"PhoneNumber").HasColumnType("nvarchar(20)").IsRequired().HasMaxLength(20);
            builder.Property(x => x.Type).HasColumnName(@"Type").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(250)").IsRequired();
            builder.Property(x => x.NatId).HasColumnName(@"NatId").HasColumnType("int").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.User).WithMany(b => b.ServiceProviders).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ServiceProvIder_User");
            builder.HasOne(a => a.ServiceType).WithMany(b => b.serviceProviders).HasForeignKey(c => c.ServiceTypeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ServiceProvIder_ServiceType");

            builder.HasIndex(x => x.PhoneNumber).HasDatabaseName("Uq_PhoneNumberServiceProvIder").IsUnique();
            builder.HasIndex(x => x.TradeName).HasDatabaseName("Uq_TradeNameServiceProvIder").IsUnique();
            builder.HasData(
         new ServiceProvider
         {
             Id = 1,
             TradeName = "متجري",
             Logo = "Upload/ServiceProvider/8d168bb7-7e70-48c1-9ea9-74f63ed8eb75.jpg",
             Description = "الافضل",
             PhoneNumber = "775752111",
             Email = "admin@gmail.com",
             NatId = 1,
             Type = "جواز",
             ServiceTypeId = 1,
             Active = true,
             UserId = "4a2e1650-21bd-4e67-832e-2e99c267a2e4",
             ActivityTypeId = 1,

         }

    );
        }
    }
}

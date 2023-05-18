using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Cart").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Total).HasColumnName(@"Total").HasColumnType("decimal").IsRequired();
            builder.Property(x => x.State).HasColumnName(@"State").HasColumnType("bit").IsRequired();
            builder.Property(x => x.Sku).HasColumnName(@"Sku").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");


            builder.HasOne(x=>x.User).WithMany(f=>f.Carts).HasForeignKey(x=>x.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Cart_User");
            builder.HasOne(x=>x.ServiceProvider).WithMany(f=>f.Carts).HasForeignKey(x=>x.ServiceProviderId).IsRequired().OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Cart_ServiceProvider");
        }
    }
}

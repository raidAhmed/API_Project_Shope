using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Order").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.OrderID).HasColumnName(@"OrderID").HasColumnType("int").IsRequired().IsRequired(false);
            builder.Property(x => x.Total).HasColumnName(@"Total").HasColumnType("decimal");
            builder.Property(x => x.Quntity).HasColumnName(@"Quntity").HasColumnType("int").IsRequired();
            builder.Property(x => x.CartId).HasColumnName(@"CartId").HasColumnType("int").IsRequired().IsRequired(false);
            builder.Property(x => x.State).HasColumnName(@"State").HasColumnType("int");
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");

            builder.HasOne(x => x.Cart).WithMany(f => f.Orders).HasForeignKey(x => x.CartId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Order_Cart");
            builder.HasOne(x => x.User).WithMany(f => f.Orders).HasForeignKey(x => x.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Orders_User");
            builder.HasOne(x => x.ServiceProvider).WithMany(f => f.Orders).HasForeignKey(x => x.ServiceProviderId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Orders_ServiceProvider");



            // builder.HasOne(a => a.product).WithMany(b => b.Orders).IsRequired(false).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Orders_Product");
            // builder.HasOne(a => a.Cart).WithMany(b => b.Orders).HasForeignKey(c => c.CartId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Orders_ServiceProvider");

        }
    }
}

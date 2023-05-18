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
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.ToTable("OrderDetails", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_OrderDetails").IsClustered();
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Sku).HasColumnName(@"Sku").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Price).HasColumnName(@"Price").HasColumnType("decimal").IsRequired();
            builder.Property(x => x.Total).HasColumnName(@"Total").HasColumnType("decimal").IsRequired();
            builder.Property(x => x.Quantity).HasColumnName(@"Quantity").HasColumnType("int").IsRequired();
            builder.Property(x => x.OrderId).HasColumnName(@"OrderId").HasColumnType("int").IsRequired();
            builder.Property(x => x.ProductId).HasColumnName(@"ProductId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Product_variantionId).HasColumnName(@"Product_variantionId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("nvarchar(450)").IsRequired(false);
            builder.Property(x => x.ServiceProviderId).HasColumnName(@"ServiceProviderId").HasColumnType("int").IsRequired();
            builder.Property(x => x.State).HasColumnName(@"State").HasColumnType("int");
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");


            builder.HasOne(x => x.Order).WithMany(f => f.OrderDetails).HasForeignKey(x => x.OrderId).IsRequired().OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OrderDetails_Order");
            builder.HasOne(x => x.Product).WithMany(f => f.OrderDetails).HasForeignKey(x => x.ProductId).IsRequired().OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OrderDetails_Product");
            builder.HasOne(x => x.Product_Variantion).WithMany(f => f.OrderDetails).HasForeignKey(x => x.Product_variantionId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OrderDetails_ProductVariation");
            builder.HasOne(x => x.User).WithMany(f => f.OrderDetails).HasForeignKey(x => x.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OrderDetails_User");
            builder.HasOne(x => x.ServiceProvider).WithMany(f => f.OrderDetails).HasForeignKey(x => x.ServiceProviderId).IsRequired().OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OrderDetails_ServiceProvider");

        }
    }
}

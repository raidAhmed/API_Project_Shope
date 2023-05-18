using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    public class CartDetailsConfigration : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.ToTable("CartDetails", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_CartDetails").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Sku).HasColumnName(@"Sku").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Price).HasColumnName(@"Price").HasColumnType("decimal").IsRequired();
            builder.Property(x => x.Total).HasColumnName(@"Total").HasColumnType("decimal").IsRequired();
            builder.Property(x => x.Quantity).HasColumnName(@"Quantity").HasColumnType("int").IsRequired();
            builder.Property(x => x.Total).HasColumnName(@"Total").HasColumnType("decimal").IsRequired();
            builder.Property(x => x.CartId).HasColumnName(@"CartId").HasColumnType("int").IsRequired(); 
            builder.Property(x => x.ProductId).HasColumnName(@"ProductId").HasColumnType("int").IsRequired(); 
            builder.Property(x => x.Product_variantionId).HasColumnName(@"Product_variantionId").HasColumnType("int").IsRequired(false); 
            builder.Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("nvarchar(450)").IsRequired(false); 
            builder.Property(x => x.ServiceProviderId).HasColumnName(@"ServiceProviderId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.State).HasColumnName(@"State").HasColumnType("bit");
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit");


            builder.HasOne(x => x.Cart).WithMany(f => f.CartDetails).HasForeignKey(x => x.CartId).IsRequired().OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CartDetails_Cart");
            builder.HasOne(x => x.Product).WithMany(f => f.CartDetails).HasForeignKey(x => x.ProductId).IsRequired().OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CartDetails_Product");
            builder.HasOne(x => x.Product_Variantion).WithMany(f => f.CartDetails).HasForeignKey(x => x.Product_variantionId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CartDetails_ProductVariation");
            builder.HasOne(x => x.User).WithMany(f => f.CartDetails).HasForeignKey(x => x.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CartDetiles_User");
            builder.HasOne(x => x.ServiceProvider).WithMany(f => f.CartDetails).HasForeignKey(x => x.ServiceProviderId).IsRequired().OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CartDetiles_ServiceProvider");

        }
    }
}

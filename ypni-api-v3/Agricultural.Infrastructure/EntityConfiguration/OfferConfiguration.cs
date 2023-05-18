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
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offer", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Offer").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Type).HasColumnName(@"Type").HasColumnType("char(1)");
            builder.Property(x => x.Price).HasColumnName(@"Price").HasColumnType("decimal");
            builder.Property(x => x.PriceRequire).HasColumnName(@"PriceRequire").HasColumnType("decimal");
            builder.Property(x => x.QtRequire).HasColumnName(@"QtRequire").HasColumnType("int");
            builder.Property(x => x.serviceProviderId).HasColumnName(@"serviceProviderId").HasColumnType("int").IsRequired();
            builder.Property(x => x.ProductId).HasColumnName(@"ProductId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.State).HasColumnName(@"State").HasColumnType("char(1)").IsRequired();
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit").IsRequired();


            builder.HasOne(a => a.product).WithMany(b => b.Offers).IsRequired(false).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Offers_Product");
            builder.HasOne(a => a.serviceProvider).WithMany(b => b.Offers).HasForeignKey(c => c.serviceProviderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Offers_ServiceProvider");


        }
    }
}

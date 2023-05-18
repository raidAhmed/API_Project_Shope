using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class Product_UnitConfigration : IEntityTypeConfiguration<Product_Unit>
    {
        public void Configure(EntityTypeBuilder<Product_Unit> builder)
        {
            builder.HasOne(x=>x.Unit).WithMany(f=>f.product_Units).HasForeignKey(x=>x.UnitId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x=>x.Prodact).WithMany(f=>f.product_Units).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}

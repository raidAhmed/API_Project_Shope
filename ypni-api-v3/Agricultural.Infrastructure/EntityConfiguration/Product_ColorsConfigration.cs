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
    internal class Product_ColorsConfigration : IEntityTypeConfiguration<Product_Colors>
    {
        public void Configure(EntityTypeBuilder<Product_Colors> builder)
        {
            builder.HasOne(x => x.Product).WithMany(f => f.Product_Colors).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.Color).WithMany(f => f.Product_Colors).HasForeignKey(x => x.ColorId).OnDelete(DeleteBehavior.ClientSetNull);
            
        }
    }
}

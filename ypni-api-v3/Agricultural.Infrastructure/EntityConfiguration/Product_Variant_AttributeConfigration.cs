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
    internal class Product_Variant_AttributeConfigration : IEntityTypeConfiguration<Product_Variant_Attribute>
    {
        public void Configure(EntityTypeBuilder<Product_Variant_Attribute> builder)
        {
            builder.HasOne(x => x.Product).WithMany(f => f.product_Variant_Attributes).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.Product_Attribute).WithMany(f => f.product_Variant_Attributes).HasForeignKey(x => x.Product_AttributeId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

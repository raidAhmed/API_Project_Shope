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
    internal class Product_variantionConfigration : IEntityTypeConfiguration<Product_variantion>
    {
        public void Configure(EntityTypeBuilder<Product_variantion> builder)
        {
            builder.HasOne(x=>x.Product).WithMany(f=>f.product_Variantions).HasForeignKey(x=>x.ProductId);
        }
    }
}

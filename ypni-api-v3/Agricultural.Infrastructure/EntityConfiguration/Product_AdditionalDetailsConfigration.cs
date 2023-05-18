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
    internal class Product_AdditionalDetailsConfigration : IEntityTypeConfiguration<Product_AdditionalDetails>
    {
        public void Configure(EntityTypeBuilder<Product_AdditionalDetails> builder)
        {
           builder.HasOne(x=>x.Product).WithMany(f=>f.Product_AdditionalDetails).HasForeignKey(x=>x.ProductId);
        }
    }
}

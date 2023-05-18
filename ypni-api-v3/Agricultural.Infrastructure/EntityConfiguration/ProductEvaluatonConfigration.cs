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
    internal class ProductEvaluatonConfigration : IEntityTypeConfiguration<ProductEvaluaton>
    {
        public void Configure(EntityTypeBuilder<ProductEvaluaton> builder)
        {
            builder.HasOne(x=>x.User).WithMany(f=>f.productEvaluatons).IsRequired(false).HasForeignKey(c=>c.UserId).OnDelete(DeleteBehavior.ClientSetNull);    
            builder.HasOne(x=>x.Product).WithMany(f=>f.productEvaluatons).IsRequired(false).HasForeignKey(c=>c.ProductId).OnDelete(DeleteBehavior.ClientSetNull);    
        }
    }
}

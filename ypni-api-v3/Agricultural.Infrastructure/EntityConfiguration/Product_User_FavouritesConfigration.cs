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
    internal class Product_User_FavouritesConfigration : IEntityTypeConfiguration<Product_User_Favourites>
    {
        public void Configure(EntityTypeBuilder<Product_User_Favourites> builder)
        {
            builder.HasOne(x => x.User).WithMany(f => f.product_User_Favourites).IsRequired(false).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.Product).WithMany(f => f.product_User_Favourites).IsRequired(false).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

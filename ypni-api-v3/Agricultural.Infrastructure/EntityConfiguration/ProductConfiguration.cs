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
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "dbo");
            builder.HasOne(x => x.ActivityType)
                                        .WithMany(f => f.Products)
                                        .HasForeignKey(x => x.ActivityTypeId)
                                        .OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false);
            builder.HasOne(x => x.MainClassification)
                                        .WithMany(f => f.Products)
                                        .HasForeignKey(x => x.MainClassificationId)
                                        .OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false);
            builder.HasOne(x => x.AdditionalSections)
                                        .WithMany(f => f.Products)
                                        .HasForeignKey(x => x.AdditionalSectionsId)
                                        .OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false);
            builder.HasOne(x => x.SpecialSections)
                                        .WithMany(f => f.Products)
                                        .HasForeignKey(x => x.SpecialSectionsId)
                                        .OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false);
            builder.HasOne(x => x.ServiceProvider)
                                        .WithMany(f => f.Products)
                                        .HasForeignKey(x => x.ServiceProviderId)
                                        .OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false);
            builder.HasOne(x => x.Brand)
                                        .WithMany(f => f.Products)
                                        .HasForeignKey(x => x.BrandId)
                                        .OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false);
            builder.HasOne(x => x.User)
                                       .WithMany(f => f.Products)
                                       .HasForeignKey(x => x.UserId)
                                       .OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false);

        }
    }
}

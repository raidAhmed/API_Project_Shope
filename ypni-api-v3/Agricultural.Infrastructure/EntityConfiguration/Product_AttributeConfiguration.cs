

using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    public class Product_AttributeConfiguration : IEntityTypeConfiguration<Product_Attribute>
    {
        public void Configure(EntityTypeBuilder<Product_Attribute> builder)
        {
            builder.ToTable("Product_Attribute", "dbo");
            builder.HasKey(x => x.Id).HasName("Pk_Product_Attribute").IsClustered();
            builder.HasData(
             new Product_Attribute
             {
                 Id =1,
                 Name = "الحجم",

             }

        );  
            builder.HasData(
             new Product_Attribute
             {
                 Id =2,
                 Name = "النوع",

             }

        );
        }
    }
}

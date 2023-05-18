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
    public class CheckOutConfiguration : IEntityTypeConfiguration<CheckOut>
    {
        public void Configure(EntityTypeBuilder<CheckOut> builder)
        {
            builder.ToTable("CheckOut", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_CheckOut").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();

        }
    }
}

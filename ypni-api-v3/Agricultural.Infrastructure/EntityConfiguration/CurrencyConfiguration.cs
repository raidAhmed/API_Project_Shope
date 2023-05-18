﻿using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currency", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Currency").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
        }
    }
}

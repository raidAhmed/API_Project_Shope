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
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_News").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Topic).HasColumnName(@"Topic").HasColumnType("nvarchar(100)");
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(500)").IsRequired(false);
            builder.Property(x => x.ImageUrl).HasColumnName(@"ImageUrl").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.CreatedAt).HasColumnName(@"CreatedAt").HasColumnType("Date").IsRequired(false);
            builder.Property(x => x.DeleteAt).HasColumnName(@"DeleteAt").HasColumnType("Date").IsRequired(false);
            builder.Property(x => x.ProductId).HasColumnName(@"ProductId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.MarketsId).HasColumnName(@"MarketsId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.State).HasColumnName(@"State").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit").IsRequired();

            builder.HasOne(a => a.Markets).WithMany(b => b.News).HasForeignKey(c => c.MarketsId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Newss_Markets");


        }
    }
}

using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class ComplainantPicConfiguration : IEntityTypeConfiguration<ComplainantPic>
    {
        
        public void Configure(EntityTypeBuilder<ComplainantPic> builder)
        {
            builder.ToTable("ComplainantPic", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ComplainantPic").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Image).HasColumnName(@"Image").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ComplainantToPartyId).HasColumnName(@"ComplainantToPartyId").HasColumnType("int").IsRequired(false);
            // Foreign keys
            builder.HasOne(a => a.ComplainantToParty).WithMany(b => b.ComplainantPics).IsRequired(false).HasForeignKey(c => c.ComplainantToPartyId).OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false).HasConstraintName("FK_ComplainantPic_ComplainantToParty");
        }
    }
}

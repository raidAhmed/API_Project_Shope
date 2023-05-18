using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class ConsultationRequestPicConfiguration : IEntityTypeConfiguration<ConsultationRequestPic>
    {
        
        public void Configure(EntityTypeBuilder<ConsultationRequestPic> builder)
        {
            builder.ToTable("ConsultationRequestPic", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ConsultationRequestPicc").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Image).HasColumnName(@"Image").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ConsultationRequestId).HasColumnName(@"ConsultationRequestId").HasColumnType("int");
                   // Foreign keys
            builder.HasOne(a => a.ConsultationRequest).WithMany(b => b.ConsultationRequestPics).IsRequired(false).HasForeignKey(c => c.ConsultationRequestId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ConsultationRequestPicc_ConsultationRequest");
        }
    }
}

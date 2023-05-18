using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    public class SP_AdressConfiguration : IEntityTypeConfiguration<SP_Address>
    {
        public void Configure(EntityTypeBuilder<SP_Address> builder)
        {
            builder.ToTable("Address", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Address").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.DirectorateId).HasColumnName(@"DirectorateId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Street).HasColumnName(@"Street").HasColumnType("nvarchar(100)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(250)").IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.Active).HasColumnName(@"Active").HasColumnType("bit").HasDefaultValue(1);
            // Foreign keys
            builder.HasOne(a => a.User).WithMany(b => b.SP_Address).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SP_Address_User");
            builder.HasOne(a => a.Directorate).WithMany(b => b.SP_Address).HasForeignKey(c => c.DirectorateId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SP_Address_Directorate");

        }
    }
}

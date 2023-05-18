using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class WorkingHoursConfiguration : IEntityTypeConfiguration<WorkingHours>
    {
        
        public void Configure(EntityTypeBuilder<WorkingHours> builder)
        {

            builder.HasOne(a => a.Weekdays).WithMany(b => b.WorkingHours).HasForeignKey(c => c.WeekdaysId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_WorkingHours_weekdays");
            builder.HasOne(a => a.WorkinPoeriods).WithMany(b => b.WorkingHours).HasForeignKey(c => c.WorkinPoeriodsId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_WorkingHours_WorkinPoeriods");
            builder.HasOne(a => a.ServiceProvider).WithMany(b => b.WorkingHours).HasForeignKey(c => c.ServiceProviderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_WorkingHours_ServiceProvIder");

        }
    }
}

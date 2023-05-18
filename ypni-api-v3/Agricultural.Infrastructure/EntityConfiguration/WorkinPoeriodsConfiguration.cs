using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class WorkinPoeriodsConfiguration : IEntityTypeConfiguration<WorkinPoeriods>
    {
        
        public void Configure(EntityTypeBuilder<WorkinPoeriods> builder)
        {
            
            builder.HasData(
               new WorkinPoeriods
               {
                   Id = 1,
                   Name = "فترة",
                   
               },
                  new WorkinPoeriods
                  {
                      Id = 2,
                      Name = "فترتين",

                  },
                new WorkinPoeriods
                 {
                      Id = 3,
                      Name = "ساعه24",

                  }

               );
        }
    }
}

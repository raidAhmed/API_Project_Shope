using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class WeekdaysConfiguration : IEntityTypeConfiguration<Weekdays>
    {
        
        public void Configure(EntityTypeBuilder<Weekdays> builder)
        {

            builder.HasData(
             new Weekdays
             {
                 Id = 1,
                 Name = "السبت",
             },
             new Weekdays
             {
                 Id = 2,
                 Name = "الاحد",
             },
               new Weekdays
               {
                   Id = 3,
                   Name = "الاثنين",
               },
                 new Weekdays
                 {
                     Id = 4,
                     Name = "الثلاثاء",
                 },
                   new Weekdays
                   {
                       Id = 5,
                       Name = "الاربعاء",
                   },
                     new Weekdays
                     {
                         Id = 6,
                         Name = "الخميس",
                     },
                     new Weekdays
                     {
                         Id = 7,
                         Name = "الجمعة",
                     }
             );
         

        }
    }
}

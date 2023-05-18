using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class WorkingHours
    {
        public int Id { get; set; } 
        public DateTime FromTime { get; set; } 
        public DateTime ToTime { get; set; }
        public int WeekdaysId { get; set; }
        public int WorkinPoeriodsId { get; set; }
        public int ServiceProviderId { get; set; }
        public int State { get; set; }
        public bool Active { get; set; }
        public Weekdays Weekdays { get; set; }
        public WorkinPoeriods WorkinPoeriods { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public WorkingHours()
        {
            Active = true;
            State = 0;
        }

        
    }
}

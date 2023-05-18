using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.WorkingHours
{
    public class WorkingHoursQueryDto
    {
        public int Id { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public int WeekdaysId { get; set; }
        public int WorkinPoeriodsId { get; set; }
        public int ServiceProviderId { get; set; }
        public int State { get; set; }
        public bool Active { get; set; }
        public string DayName { get; set; }
        public string PoriodName { get; set; }
        public string ServiceProviderName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Weekdays
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<WorkingHours> WorkingHours { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ActivityType
{
    public class ActivityTypeQueryDto
    {
        public int Id { get; set; }
        public String ActivityName { get; set; }

        public bool Active { get; set; }
    }
}

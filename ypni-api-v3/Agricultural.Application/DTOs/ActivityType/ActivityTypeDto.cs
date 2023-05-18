using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ActivityType
{
    public class ActivityTypeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل أسم النشاط  ")]
        public String ActivityName { get; set; }
        public bool Active { get; set; }

    }
}

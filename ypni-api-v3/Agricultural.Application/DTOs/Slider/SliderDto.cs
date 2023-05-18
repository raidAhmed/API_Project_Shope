using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Slider
{
    public class SliderDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل الإسم   ")]
        public string Name { get; set; }
        public string Details { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? ServiceProviderId { get; set; }
        public bool Active { get; set; }
    }
}

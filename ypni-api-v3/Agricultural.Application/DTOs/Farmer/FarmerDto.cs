using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Farmer
{
    public class FarmerDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "  أدحل طول الارض  ")]
        public string EarthLength { get; set; }
        [Required(ErrorMessage = "  أدحل معلومات الارض  ")]
        public string EarthInfo { get; set; }
        [Required(ErrorMessage = "  أدحل عرض الارض  ")]
        public string EarthWidth { get; set; }
        public int? ServiceProviderId { get; set; }
        public bool? Active { get; set; }
    }
}

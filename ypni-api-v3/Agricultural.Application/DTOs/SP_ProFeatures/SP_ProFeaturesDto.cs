using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.SP_ProFeatures
{
    public class SP_ProFeaturesDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل أسم المدينة  ")]
        [MaxLength(10, ErrorMessage = "يجب ان يكون حجم الحقل اقل من 10 ")]
        public string Name { get; set; }

        public bool Active { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Directorate
{
    public class DirectorateDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال اسم المديرية     ")]
        public string Name { get; set; }
        public int? CityId { get; set; }
    }
}

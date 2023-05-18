using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ConsultationRequestPic
{
    public class ConsultationRequestPicDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "  أدحل عنوان الطلب  ")]
        public string Image { get; set; }
        public int ConsultationRequestId { get; set; }
    }
}

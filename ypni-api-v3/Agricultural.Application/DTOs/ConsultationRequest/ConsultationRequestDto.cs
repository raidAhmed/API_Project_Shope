using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ConsultationRequest
{
    public class ConsultationRequestDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "  أدحل عنوان الطلب  ")]
        public string Topic { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "  أختار اسم مزود الخدمة  ")]
        public int ServiceProviderId { get; set; }
        [Required(ErrorMessage = " أختار أسم المزارع   ")]
        public int FarmerId { get; set; }
        public bool RequestState { get; set; }
        public bool Active { get; set; }
    }
}

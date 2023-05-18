using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ConsultationRequestPic
{
    public class ConsultationRequestPicQueryDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int ConsultationRequestId { get; set; }
    }
}

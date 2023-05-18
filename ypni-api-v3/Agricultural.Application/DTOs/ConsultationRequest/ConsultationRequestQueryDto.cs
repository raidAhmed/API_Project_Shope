using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ConsultationRequest
{
    public class ConsultationRequestQueryDto
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public int ServiceProviderId { get; set; }
        public int FarmerId { get; set; }
        public bool RequestState { get; set; }
        public bool Active { get; set; }
    }
}

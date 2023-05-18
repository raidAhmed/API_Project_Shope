using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class ConsultationRequestPic
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int? ConsultationRequestId { get; set; }
        public bool Active { get; set; }
        public ConsultationRequest ConsultationRequest { get; set; }


        public ConsultationRequestPic()
        {
            Active = true;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.SP_MainClassification
{
    public class SP_MainClassificationDto
    {
        public int Id { get; set; }
        public int MainClassificationId { get; set; }
        public int? ServiceProviderId { get; set; }
        public bool Active { get; set; }
    } 
    public class SP_MainClassificationDtoApi
    {
        public int MainClassificationId { get; set; }
        public int? ServiceProviderId { get; set; }
    }
}

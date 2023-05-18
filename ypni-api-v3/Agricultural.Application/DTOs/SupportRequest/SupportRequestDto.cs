using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.SupportRequest
{
    public class SupportRequestDto
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int OfficialPartyId { get; set; }
        public int FarmerId { get; set; }
        public bool requestState { get; set; }
        public bool Active { get; set; }
    }
}

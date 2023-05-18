using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ComplainantToParty
{
    public class ComplainantToPartyQueryDto
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string TypeofMesseage { get; set; }
        public string SenderId { get; set; }
        public string ReciverId { get; set; }
        public int ServiceType { get; set; }
        public bool requestState { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

using Agricultural.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class ComplainantToParty
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string TypeofMesseage { get; set; }
        public string SenderId { get; set; }
        public string ReciverId { get; set; }
        public bool requestState { get; set; }
        public int ServiceType { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }

        public List<ComplainantPic> ComplainantPics { get; set; }

        public ComplainantToParty()
        {
            Active = true;
            CreatedAt = DateTime.Now;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ComplainantToParty
{
    public class ComplainantToPartyChatsDto
    {
        public string TradeName { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Topic { get; set; }
        public int count { get; set; }
        public string CreatedAt { get; set; }
    }
}

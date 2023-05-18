using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.User_Bank
{
    public class User_BankQueryDto
    {
        public int Id { get; set; }
        public int BanksAccountNum { get; set; }
        public string BanksName { get; set; }
        public int BanksId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
        public bool Active { get; set; }
    }
}

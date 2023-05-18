using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class User_Bank
    {
        public int Id { get; set; }
        public int BanksAccountNum { get; set; }
        public int BanksId { get; set; }
        public string UserId { get; set; }
        public bool Active { get; set; }
        public User User { get; set; }
        public Banks Banks { get; set; }
      public User_Bank()
        {
            Active=true;
        }
    }
}

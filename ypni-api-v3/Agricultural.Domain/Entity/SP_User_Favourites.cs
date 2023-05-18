using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class SP_User_Favourites
    {
        public int Id { get; set; }
        public String UserId { get; set; }
        public int ServiceProviderId { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public User User { get; set; }
        public ServiceProvider ServiceProvider { get; set; }

        public SP_User_Favourites()
        {
            Active = true;
        }
    }
}

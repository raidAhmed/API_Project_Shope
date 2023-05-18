using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Product_User_Favourites
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public String UserId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}

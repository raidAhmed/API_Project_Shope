using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Cart
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public decimal Total { get; set; }
        public String? UserId { get; set; }
        public bool State { get; set; }
        public bool Active { get; set; }
        public int ServiceProviderId { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public User User { get; set; }

        public List<CartDetails> CartDetails { get; set; }
        public List<Order> Orders { get; set; }
        //public List<Order> Orders { get; set; }
        public Cart()
        {
            Active = true;
            State=true;
        }
    }
}

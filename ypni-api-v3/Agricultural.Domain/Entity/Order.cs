using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int? OrderID { get; set; }
        public decimal Total { get; set; }
        public int Quntity { get; set; }
        public String? UserId { get; set; }
        public int? CartId { get; set; }

        public int State { get; set; }
        public bool Active { get; set; }
        public int? ServiceProviderId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public User User { get; set; }
        public Cart Cart { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }

       // public Cart Cart { get; set; }
        public Order()
        {
            Active = true;
            State = 1;
        }

    }
}

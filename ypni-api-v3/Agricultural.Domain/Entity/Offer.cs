using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Offer
    {
        public int Id { get; set; }
        public char Type { get; set; }
        public int ApplyTo { get; set; }
        public decimal Price { get; set; }
        public int QtRequire { get; set; }
        public decimal PriceRequire { get; set; }
        public int? ProductId { get; set; }
        public int serviceProviderId { get; set; }
        public char State { get; set; }
        public bool Active { get; set; }
        public Product product { get; set; }
        public ServiceProvider serviceProvider { get; set; }    

        public Offer()
        {
            Active = true;
        }
    }
}

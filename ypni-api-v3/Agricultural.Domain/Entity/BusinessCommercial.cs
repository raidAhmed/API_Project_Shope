using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class BusinessCommercial
    {
        public int Id { get; set; }
        public string  BankAccount { get; set; }
        public string TradeRecord { get; set; }
        public int? ServiceProviderId { get; set; }
        public bool Active { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public BusinessCommercial()
        {
            Active = true;
        }


    }
}

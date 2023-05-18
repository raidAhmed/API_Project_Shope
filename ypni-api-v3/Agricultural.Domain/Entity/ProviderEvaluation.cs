using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class ProviderEvaluation
    {
        public int Id { get; set; }
        public int value { get; set; }
        public int ServiceProviderId { get; set; }
        public String UserId { get; set; }
        public bool Active { get; set; }
        public User User { get; set; }
        public ServiceProvider ServiceProvider { get; set; }

        public ProviderEvaluation() => Active = true;


    }
}

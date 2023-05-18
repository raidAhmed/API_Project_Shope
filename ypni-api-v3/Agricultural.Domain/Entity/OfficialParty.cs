using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class OfficialParty
    {
        public int Id { get; set; }
        public string OrganisationType { get; set; }
        public int? ServiceProviderId { get; set; }
        public bool Active { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public List<SupportRequest> SupportRequests { get; set; }
        public OfficialParty()
        {
            Active = true;
        }
    }
}

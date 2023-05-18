using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.OfficialParty
{
    public class OfficialPartyQueryDto
    {
        public int Id { get; set; }
        public string OrganisationType { get; set; }
        public int ServiceProviderId { get; set; }
        public bool Active { get; set; }
    }
}

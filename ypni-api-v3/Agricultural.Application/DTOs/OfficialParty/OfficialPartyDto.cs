using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.OfficialParty
{
    public class OfficialPartyDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = " أدحل أسم الجهةالرسمية  ")]
        public string OrganisationType { get; set; }
        public int? ServiceProviderId { get; set; }
        public bool? Active { get; set; }   
    }
}

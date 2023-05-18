using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ComplainantToParty
{
    public class Complminttopartyapi
    {
        public string Id { get; set; }
        public string Username { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public string ServiceTypeName { get; set; }
        public string ActivityTypeName { get; set; }
        //public byte State { get; set; }
        //public bool Active { get; set; }
        //  public bool Status { get; set; }

        public List<ComplainantToPartyQueryDto> ComplainantToPartyDto { get; set; }

    }
}

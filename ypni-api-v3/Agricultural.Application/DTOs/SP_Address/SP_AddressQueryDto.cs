using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.SP_Address
{
    public class SP_AddressQueryDto
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int DirectorateId { get; set; }
        public string Street { get; set; }
        public string CityName { get; set; }
        public string DirectorateName { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public bool? State { get; set; }
        public bool Active { get; set; }
    }
}

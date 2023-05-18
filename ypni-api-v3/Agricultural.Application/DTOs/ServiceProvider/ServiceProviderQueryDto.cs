using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ServiceProvider
{
    public class ServiceProviderQueryDto
    {
        public int Id { get; set; }
        public int idForFavo { get; set; }
        public string TradeName { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string ActivityTypeName { get; set; }
        public string ServiceTypeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        // from user
        public string UserId { get; set; }
        public int? NatId { get; set; }
        // from activity type
        public int ActivityTypeId { get; set; }
        public int ServiceTypeId { get; set; }
        public int? ViewPlace { get; set; }
        public bool Active { get; set; }
        public string Rating { get; set; }
    }
}

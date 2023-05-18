using Agricultural.Application.DTOs.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.HomeDashboard
{
    public class HomeDto
    {
        public int SPCounts { get; set; }
        public int UsersCount { get; set; }
        public int UsersCustomerCount { get; set; }
        public int ProductsCount { get; set; }
        public int OrdersCount { get; set; }

       public  List<ServiceProviderQueryDto> serviceproviders = new List<ServiceProviderQueryDto>();
    }
}

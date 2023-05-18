using Agricultural.Application.DTOs.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.HomeDashboard
{
    public class SP_HomeDto
    {
        public int SP_id { get; set; }
        public string SP_name { get; set; }

        public int ProductsCount { get; set; }
        public int CustomrsCount { get; set; }
        public int OrdersCount { get; set; }
        public decimal Revenus { get; set; }

       public List<OrderDetailsDtoViewSELSp> orders = new List<OrderDetailsDtoViewSELSp>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Order
{
    public class OrderQueryDto
    {
        public int Id { get; set; }
        public int? OrderID { get; set; }
        public decimal Total { get; set; }
        public int Quntity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public String? UserId { get; set; }
        public int? CartId { get; set; }
        public int State { get; set; }
        public bool Active { get; set; }
        public int? ServiceProviderId { get; set; }
    }

}


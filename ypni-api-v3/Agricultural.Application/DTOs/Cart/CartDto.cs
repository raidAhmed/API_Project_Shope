using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Cart
{
    public class CartDto
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public decimal Total { get; set; }
        public String? UserId { get; set; }
        public bool State { get; set; }
        public bool Active { get; set; }
        public int ServiceProviderId { get; set; }
    }
}

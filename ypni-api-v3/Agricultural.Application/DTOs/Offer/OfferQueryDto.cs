using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Offer
{
    public class OfferQueryDto
    {
        public int Id { get; set; }
        public char Type { get; set; }
        public int ApplyTo { get; set; }
        public decimal Price { get; set; }
        public decimal QtRequire { get; set; }
        public decimal PriceRequire { get; set; }
        public int ProductId { get; set; }
        public char State { get; set; }

    }
}

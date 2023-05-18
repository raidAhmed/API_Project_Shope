using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Offer
{
    public class OfferDto
    {
        public int Id { get; set; }
       // [Required(ErrorMessage = " أدحل أسم النشاط  ")]
        public char Type { get; set; }
      //  [Required(ErrorMessage = " أدحل أسم النشاط  ")]
        public int ApplyTo { get; set; }
      //  [Required(ErrorMessage = " أدحل أسم النشاط  ")]
        public decimal Price { get; set; }
     //   [Required(ErrorMessage = " أدحل أسم النشاط  ")]
        public decimal QtRequire { get; set; }
        public decimal PriceRequire { get; set; }
        public int ProductId { get; set; }
        public char State { get; set; }
    }
}

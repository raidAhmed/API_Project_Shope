using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.BusinessCommercial
{
    public class BusinessCommercialDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل رقم الحساب البنكي   ")]
        public string BankAccount { get; set; }
        [Required(ErrorMessage = " أدحل  السجل التجاري  ")]
        public string TradeRecord { get; set; }
        public int? ServiceProviderId { get; set; }
        public bool Active { get; set; }
    }
}

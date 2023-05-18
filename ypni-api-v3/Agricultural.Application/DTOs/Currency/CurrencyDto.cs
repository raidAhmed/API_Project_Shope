using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Currency
{
    public class CurrencyDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل أسم العملة  ")]
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}

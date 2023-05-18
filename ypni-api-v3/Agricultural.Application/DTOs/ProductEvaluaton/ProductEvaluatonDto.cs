using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ProductEvaluaton
{
    public class ProductEvaluatonDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int? ProductId { get; set; }
        public string UserId { get; set; }
    }
}

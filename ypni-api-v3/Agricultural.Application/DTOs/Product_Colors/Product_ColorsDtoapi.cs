using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Product_Colors
{
    public class Product_ColorsDtoapi
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string Colorcode { get; set; }
        public int ProductId { get; set; }
        public bool Active { get; set; }
    }
}

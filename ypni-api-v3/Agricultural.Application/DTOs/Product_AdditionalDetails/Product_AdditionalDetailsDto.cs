using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Product_AdditionalDetails
{
    public class Product_AdditionalDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }
    }
}

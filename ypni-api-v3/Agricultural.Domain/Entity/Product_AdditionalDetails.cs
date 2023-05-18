using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Product_AdditionalDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }
        public bool Active { get; set; }
        public Product Product { get; set; }

        public Product_AdditionalDetails()
        {
            Active = true;
        }

    }
}

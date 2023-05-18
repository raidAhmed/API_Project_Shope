using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Product_Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
        public bool Active { get; set; }
        public Product Product { get; set; }

        public Product_Image()
        {
            Active = true;
        }
    }
}

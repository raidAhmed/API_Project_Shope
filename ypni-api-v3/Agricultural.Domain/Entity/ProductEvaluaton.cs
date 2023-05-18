using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class ProductEvaluaton
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int? ProductId { get; set; }
        public string UserId { get; set; }
        public bool Active { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }

        public ProductEvaluaton()
        {
            Active = true;
        }
    }
}

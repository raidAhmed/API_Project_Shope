using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Slider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? ServiceProviderId { get; set; }
        public bool Active { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
       public List<SliderImages> SliderImages { get; set; }

    public  Slider()
        {
            Active = true; 
        }

    }
}

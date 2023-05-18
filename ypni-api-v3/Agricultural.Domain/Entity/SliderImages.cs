using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class SliderImages
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }
        public int? SliderId { get; set; }
        public Slider Slider { get; set; }
      
       
    public SliderImages()
        {
            Active = true; 
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.SliderImages
{
    public class SliderImagesQueryDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public int? SliderId { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.SliderImages
{
    public class SliderImagesDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public int? SliderId { get; set; }
       // [Required(ErrorMessage = " أختر  صورة  ")]
        public IFormFile? File { get; set; }
    }
}

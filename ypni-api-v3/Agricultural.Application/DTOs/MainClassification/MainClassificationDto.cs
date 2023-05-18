using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Agricultural.Application.DTOs.MainClassification
{
    public class MainClassificationDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "    يجب ادخال الاسم ")]
        public string MainClassificationName { get; set; }
        [Required(ErrorMessage = " أدحل أسم النشاط  ")]
        public int? ActivityTypeId { get; set; }
        //[Required(ErrorMessage = " أختر  صورة  ")]
        public IFormFile File { get; set; }

        public string ImageUrl { get; set; }
        public bool Active { get; set; }
    }
}

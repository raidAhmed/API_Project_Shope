using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ComplainantPic
{
    public class ComplainantPicDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل أسم الصورة  ")]
        public string Image { get; set; }
        [Required(ErrorMessage = " أختار أسم الشكوى   ")]
        public int ComplainantToPartyId { get; set; }
    }
}

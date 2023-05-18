using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.AdditionalSections
{
    public class AdditionalSectionsDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل أسم  القسم الاضافي  ")]
        public String AdditionalSectionsName { get; set; }

        public int? Rank { get; set; }
        public string ImageUrl { get; set; }
        public int? ParnetSectionId { get; set; }
     //   [Required(ErrorMessage = "  أختار أسم القسم الرئيسي    ")]
        public int? MainClassificationId { get; set; }

       // [NotMapped]
       // [Required(ErrorMessage = " أختر  صورة  ")]
        public IFormFile File { get; set; }
        public bool Active { get; set; }
    }
}

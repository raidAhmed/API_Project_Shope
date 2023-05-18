using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.SpecialSections
{
    public class SpecialSectionsDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل أسم القسم الاضافي  ")]
        public string SpecialSectionName { get; set; }
        public string ImageUrl { get; set; }
        public int? MainClassificationId { get; set; }
        public int? AdditionalSectionsId { get; set; }
        public int? ParnetSectionId { get; set; }
        public int Rank { get; set; }
        public int? ServiceProviderId { get; set; }
        public String? ServiceProviderName { get; set; }
        public bool Active { get; set; }

        [NotMapped]
        [Required(ErrorMessage = " أختر  صورة  ")]
        public IFormFile? File { get; set; }

    }
}

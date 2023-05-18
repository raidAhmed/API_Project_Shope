using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ServiceProvider
{
    public class ServiceProviderDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل أسم التجاري  ")]
        public string TradeName { get; set; }
        public string? Logo { get; set; }
        [Required(ErrorMessage = " أدحل الإيميل الخاص بالتواصل  ")]
        public string Email { get; set; }
        [Required(ErrorMessage = " أدحل رقم الهاتف الخاص بالتواصل  ")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = " أدحل نوع البطاقة الشخصية  ")]
        public string Type { get; set; }
        [Required(ErrorMessage = " أدحل الرقم  الوطني  ")]
        public int? NatId { get; set; }
        public string Description { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        // from user
        public string? UserId { get; set; }
        // from activity type
        [Required(ErrorMessage = " أختار نوع  النشاط  ")]
        public int? ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }
        public int ViewPlace { get; set; }
        public IFormFile? File { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.User
{
    public class ChangePassWordDto
    {
        public string? Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = " يجب أن تدخل كلمة المرور الحالية ")]
        public string CurrentPassword { get; set; }
        [Required]
        [StringLength(100,MinimumLength =6, ErrorMessage = " يجب أن تكون كلمة المرور اكثر من ستة حروف وأرقام ورموز ")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "كلمة المرور غير متطابقة")]
        public string ConfeirmPassword { get; set; }
    }
}

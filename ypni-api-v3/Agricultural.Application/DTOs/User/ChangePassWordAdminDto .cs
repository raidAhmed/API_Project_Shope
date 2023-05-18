using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.User
{
    public class ChangePassWordAdminDto
    {
        public string? Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = " يجب أن تكون كلمة المرور اكثر من ستة حروف وأرقام ورموز ")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "كلمة المرور غير متطابقة")]
        public string ConfeirmPassword { get; set; }
    }
}

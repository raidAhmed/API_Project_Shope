using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.User_Bank
{
    public class User_BankDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " أدحل رقم الحساب  ")]
        public int BanksAccountNum { get; set; }
        [Required(ErrorMessage = " أختار أسم البنك أو المحفظة  ")]
        public int BanksId { get; set; }
        public string UserId { get; set; }
        public bool Active { get; set; }
    }
}

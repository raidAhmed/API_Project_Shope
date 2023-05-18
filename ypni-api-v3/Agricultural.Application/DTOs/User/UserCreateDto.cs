////////////////////////////////////////////////
///         Ibrahim AL-afif                ///
///         ib2050a@gmail.com            ///
///         +967 777 384 772           ///
///generated UserCreateDto.cs///
//////////////////////////////////////
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Agricultural.Application.DTOs.User
{
    public class UserCreateDto
    {

        public string? Id { get; set; }
        [Required(ErrorMessage = " √œÕ· √”„ «·„” Œœ„  ")]
        public string Username { get; set; }

        [Required(ErrorMessage = " √œÕ· «·≈”„ «·À·«ÀÌ  ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = " √œÕ· «··ﬁ»   ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = " √œÕ· «·≈Ì„Ì·   ")]
        [EmailAddress]

        public string Email { get; set; }
        [Required(ErrorMessage = " √œÕ· —ﬁ„ «·Â« ›  ")]
        [Phone]
        public string PhoneNumber { get; set; }


        public string? Image { get; set; }

        [Required]
        [StringLength(100,MinimumLength =6, ErrorMessage = " ÌÃ» √‰  ﬂÊ‰ ﬂ·„… «·„—Ê— «ﬂÀ— „‰ ” … Õ—Ê›  ")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string? ConfeirmPassword { get; set; }


        public byte UserType { get; set; }
         

        public byte State { get; set; }
        public bool Status { get; set; }


        public bool Active { get; set; }
        public IFormFile? File { get; set; }

    }
}

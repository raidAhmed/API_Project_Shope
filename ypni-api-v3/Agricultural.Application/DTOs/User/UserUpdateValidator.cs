using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Agricultural.Application.DTOs.User
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateValidator()
        {



            RuleFor(v => v.FirstName).NotEmpty();



            RuleFor(v => v.LastName).NotEmpty();



            RuleFor(v => v.UserType).NotEmpty();



            RuleFor(v => v.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).NotEmpty();



            RuleFor(v => v.PhoneNumber).NotEmpty();
        }
    }
}

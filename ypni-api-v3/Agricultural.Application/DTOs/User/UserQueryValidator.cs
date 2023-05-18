
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using FluentValidation;

namespace Agricultural.Application.DTOs.User
{
    public class UserQueryValidator : AbstractValidator<UserQueryDto>
    {
        public UserQueryValidator()
        {


            RuleFor(v => v.FirstName).NotEmpty();
            RuleFor(v => v.LastName).NotEmpty();
            RuleFor(v => v.UserType).NotEmpty();
            RuleFor(v => v.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).NotEmpty();
            //RuleFor(v => v.Password).NotEmpty();
            RuleFor(v => v.PhoneNumber).NotEmpty();

        }
    }
}

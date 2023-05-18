
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using FluentValidation;

namespace Agricultural.Application.DTOs.User
{
    public class UserCreateValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateValidator()
        {


            RuleFor(v => v.Username).NotEmpty();


            RuleFor(v => v.FirstName).NotEmpty();


            RuleFor(v => v.PhoneNumber).NotEmpty();


            RuleFor(v => v.Password).NotEmpty();


            RuleFor(v => v.UserType).NotNull();


            RuleFor(v => v.LastName).NotEmpty();


            RuleFor(v => v.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).NotEmpty();


        }
    }
}

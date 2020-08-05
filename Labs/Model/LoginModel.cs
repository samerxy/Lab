using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(d => d.UserName).NotEmpty().WithMessage("enter name");
            RuleFor(d => d.Password).NotEmpty().WithMessage("enter a valid password");

        }
    }
}

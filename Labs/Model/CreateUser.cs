using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class CreateUser
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int LabID { get; set; }
        public int RoleID { get; set; }
    }
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(d => d.Name).NotEmpty().WithMessage("enter  name");
            RuleFor(d => d.Password).NotEmpty().WithMessage("enter password");
            RuleFor(d => d.UserName).NotEmpty().WithMessage("enter username");
            RuleFor(d => d.Email).NotEmpty().WithMessage("enter email");
            RuleFor(d => d.Phone).NotEmpty().WithMessage("enter phone number");
            RuleFor(d => d.RoleID).NotNull().WithMessage("enter role id");
            RuleFor(d => d.LabID).NotNull().WithMessage("enter lab id");
             
        }
    }
}

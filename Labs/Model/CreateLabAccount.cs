using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class CreateLabAccount
    {
        public string LabName { get; set; }
        public int UserID { get; set; }

    }
    public class CreateLabValidator : AbstractValidator<CreateLabAccount>
    {
        public CreateLabValidator()
        {
            RuleFor(d => d.LabName).NotEmpty().WithMessage("enter lab name");
            RuleFor(d => d.UserID).NotEmpty().WithMessage("enter user id");
            
           
        }
    }
}

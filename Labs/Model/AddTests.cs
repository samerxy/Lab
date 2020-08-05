using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class AddTests
    {
        public string TestName { get; set; }
        public int LabID { get; set; }
    }

    public class AddTestsValidator : AbstractValidator<AddTests>
    {
        public AddTestsValidator()
        {
            RuleFor(d => d.TestName).NotEmpty().WithMessage("enter test name");
            RuleFor(d => d.LabID).NotNull(); 
            
        }
    }
}

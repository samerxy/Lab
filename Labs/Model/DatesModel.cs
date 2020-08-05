using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class DatesModel
    {
        public DateTime Date { get; set; }
        public int LabID { get; set; }
    }
    public class DatesModelValidator : AbstractValidator<DatesModel>
    {
        public DatesModelValidator()
        {
            RuleFor(d => d.Date).NotEmpty().WithMessage("enter date");
            RuleFor(d => d.LabID).NotNull();
        }
    }
}

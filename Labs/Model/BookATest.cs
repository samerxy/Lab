using FluentValidation;
using Labs.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class BookATest
    {
        public string FullName { get; set; }
        public int age { get; set; }
        public string Email { get; set; }
        public int LabID { get; set; }       
        public List<int>  TestID { get; set; }
        public DateTime Date { get; set; }
        public int TimeID { get; set; }
        
    }

    public class BookATestValidator : AbstractValidator<BookATest>
    {
        public BookATestValidator()
        {
            RuleFor(f => f.FullName).NotEmpty();
            RuleFor(f => f.age).NotEmpty();
            RuleFor(f => f.Email).NotEmpty().EmailAddress();
            RuleFor(f => f.TimeID).NotNull();
            RuleFor(f => f.TestID).NotEmpty();
            RuleFor(f => f.Date).NotEmpty();
        }
    }
}

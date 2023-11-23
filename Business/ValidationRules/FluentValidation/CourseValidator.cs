using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
            //RuleFor(c => c.Price).NotEmpty(); // Price 0 olduğu zaman 'Price' boş olmamalı hatası veriyor
            RuleFor(c => c.Price).Equals(0);
            //RuleFor(c => c.Price).GreaterThanOrEqualTo(10).When(ct => ct.CategoryId == 1);
            RuleFor(c => c.Name).Must(StartWithA).WithMessage("Kurslar A harfi ile başlamalı");
        }
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.CarId).NotEmpty();

            //RuleFor(r => r.CustomerId).Must(FirstNumberOne).WithMessage("CustomerId 1 ile başlamalı");

        }

        private bool FirstNumberOne(int arg)
        {
            return arg.ToString().StartsWith("1"); //custom validation rule
        }
    }
}

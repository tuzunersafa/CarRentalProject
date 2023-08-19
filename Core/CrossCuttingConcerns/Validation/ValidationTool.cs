using Entites.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {


        public static void Validate(IValidator )
        {
            var context = new ValidationContext<object>(entity);
            RentalValidator rentalValidator = new RentalValidator();
            var result = rentalValidator.Validate(context);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

        }
    }
}

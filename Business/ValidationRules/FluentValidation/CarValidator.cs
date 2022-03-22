#region info

// Bilal Karataş20220313

#endregion

using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.Description.Length).NotEmpty();
            RuleFor(car => car.Description.Length).GreaterThan(10);

            RuleFor(car => car.BrandId).NotEmpty();
            RuleFor(car => car.BrandId).NotNull();

            RuleFor(car => car.ModelYear).LessThanOrEqualTo(DateTime.Now.Year);
        }
    }
}
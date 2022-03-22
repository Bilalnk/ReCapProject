#region info

// Bilal Karataş20220322

#endregion

using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(brand => brand.Name).NotEmpty();
            RuleFor(brand => brand.Name).NotNull();
            RuleFor(brand => brand.Name).NotEqual(" ");

            RuleFor(brand => brand.id).GreaterThan(0);
        }
    }
}
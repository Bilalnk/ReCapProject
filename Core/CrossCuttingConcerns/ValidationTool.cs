﻿#region info

// Bilal Karataş20220322

#endregion

using FluentValidation;

namespace Core.CrossCuttingConcerns
{
    public class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
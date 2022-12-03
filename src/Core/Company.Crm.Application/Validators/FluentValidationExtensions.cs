using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Company.Framework.Validators;

public static class FluentValidationExtensions
{
    public static void AddToModelState(this FluentValidation.Results.ValidationResult result, ModelStateDictionary modelState)
    {
        foreach (var error in result.Errors)
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
}

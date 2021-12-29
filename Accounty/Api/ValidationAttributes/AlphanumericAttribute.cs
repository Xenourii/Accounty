using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Accounty.Api.ValidationAttributes;

public class AlphanumericAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string str && Regex.IsMatch(str, @"^[a-zA-Z0-9]+$"))
            return ValidationResult.Success;

        return new ValidationResult("It must contain alphanumeric characters");
    }
}
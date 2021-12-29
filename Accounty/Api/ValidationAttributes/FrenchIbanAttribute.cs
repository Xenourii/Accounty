using System.ComponentModel.DataAnnotations;
using IbanNet;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Accounty.Api.ValidationAttributes;

public class FrenchIbanAttribute : ValidationAttribute
{
    private const string IsoCountryCode = "FR";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var ibanValidator = new IbanValidator();
        var result = ibanValidator.Validate(value as string);

        if (result.IsValid && result?.Country?.TwoLetterISORegionName is IsoCountryCode)
            return ValidationResult.Success;

        return new ValidationResult("It must be a valid french IBAN");
    }
}
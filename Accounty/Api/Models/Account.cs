using System.ComponentModel.DataAnnotations;
using Accounty.Api.ValidationAttributes;

namespace Accounty.Api.Models;

public class Account : BaseEntity
{
    public int? Id { get; set; }

    [Required]
    public string BankName { get; set; } = string.Empty;

    [Required]
    [FrenchIban]
    public string Iban { get; set; } = string.Empty;

    [Required]
    [Alphanumeric]
    public string Bic { get; set; } = string.Empty;

    public string? AccountOwner { get; set; }
}
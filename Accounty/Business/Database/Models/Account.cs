namespace Accounty.Business.Database.Models;

public class Account : BaseEntity
{
    public int? Id { get; set; }
    public string BankName { get; set; } = string.Empty;
    public string Iban { get; set; } = string.Empty;
    public string Bic { get; set; } = string.Empty;
    public string? AccountOwner { get; set; }
}
namespace Accounty.Exceptions;

public class AccountNotFoundException : NotFoundException
{
    public AccountNotFoundException(int id) : base($"Account with id {id} not found") { }
}
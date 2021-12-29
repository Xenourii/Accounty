using Accounty.Business.Database;
using Accounty.Business.Database.Models;
using Accounty.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Accounty.Business.Services;

public interface IAccountService
{
    IEnumerable<Account> Get();
    Task<Account> GetById(int id);
    Task<Account> Create(Account account);
    Task Delete(int id);
}

public class AccountService : IAccountService
{
    private readonly AccountDbContext _context;

    public AccountService(AccountDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Account> Get() => _context.Accounts;
    public async Task<Account> GetById(int id)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        if (account is null)
            throw new AccountNotFoundException(id);

        return account;
    }

    public async Task<Account> Create(Account account)
    {
        var createdAccount = await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
        return createdAccount.Entity;
    }

    public async Task Delete(int id)
    {
        var account = await GetById(id);
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
    }
}
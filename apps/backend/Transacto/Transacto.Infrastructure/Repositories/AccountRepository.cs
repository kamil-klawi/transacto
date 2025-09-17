/*
 * \file AccountRepository.cs
 * \brief Implementation of IAccountRepository using Entity Framework Core
 * 
 * \date 17-09-2025
 */

using Microsoft.EntityFrameworkCore;
using Transacto.Domain.Account.Entities;
using Transacto.Domain.Account.Repositories;
using Transacto.Domain.Account.ValueObjects;
using Transacto.Infrastructure.Persistence;

namespace Transacto.Infrastructure.Repositories;

public class AccountRepository(ApplicationDbContext context) : IAccountRepository
{
    public async Task<IEnumerable<Account>> GetAccounts()
    {
        return await context.Accounts.ToListAsync();
    }

    public async Task<Account> CreateAccount(Account account)
    {
        await context.Accounts.AddAsync(account);
        await context.SaveChangesAsync();
        return account;
    }

    public async Task<Account?> GetAccount(Guid id)
    {
        return await context.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task UpdateAccount(Account account)
    {
        if (account == null)
            throw new ArgumentNullException(nameof(account));
        
        context.Accounts.Update(account);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAccount(Guid id)
    {
        var account = await context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        if (account == null)
            throw new ArgumentException("Account not found");
        
        context.Accounts.Remove(account);
        await context.SaveChangesAsync();
    }

    public async Task<Money> GetAccountBalance(Guid id)
    {
        var account = await context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        return account == null ? throw new ArgumentException("Account not found") : account.Balance;
    }

    public async Task<AccountSummary> GetAccountSummary(Guid id)
    {
        var account = await context.Accounts
            .Include(a => a.Summaries)
            .FirstOrDefaultAsync(a => a.Id == id);
        if (account == null)
            throw new ArgumentException("Account not found");

        var summary = account.Summaries
            .OrderByDescending(s => s.ToDate)
            .FirstOrDefault();
        
        return summary ?? throw new ArgumentException("Account summary not found");
    }
}
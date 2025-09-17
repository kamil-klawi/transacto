/*
 * \file Account.cs
 * \brief Domain entity representing a user's bank account
 *
 * Represents a bank account in the domain layer, including its properties
 * such as balance, account type, owner, and methods for account operations
 * like deposit, withdrawal, renaming, and closing
 * 
 * \date 17-09-2025
 */

using Transacto.Domain.Account.Enums;
using Transacto.Domain.Account.ValueObjects;

namespace Transacto.Domain.Account.Entities;

public class Account
{
    public Guid Id { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public Guid UserId { get; private set; } = default!;
    public AccountType Type { get; private set; } = default!;
    public Money Balance { get; private set; } = default!;
    public bool IsClosed { get; private set; } = default!;
    public DateTime? ClosedAt { get; private set; } = default!;
    public DateTime CreatedAt { get; private set; } = default!;
    public List<AccountSummary> Summaries { get; private set; } = new();
    
    private Account() { }

    public Account(Guid id, string name, Guid userId, AccountType type, Money balance, DateTime createdAt)
    {
        Id = id;
        Name = name;
        UserId = userId;
        Type = type;
        Balance = balance;
        CreatedAt = createdAt;
        IsClosed = false;
    }
    
    public void Rename(string newName)
    {
        Name = newName;
    }
    
    public void Deposit(Money amount)
    {
        Balance += amount;
    }
    
    public void Withdraw(Money amount)
    {
        Balance -= amount;
    }
    
    public void Close()
    {
        IsClosed = true;
        ClosedAt = DateTime.UtcNow;
    }
}
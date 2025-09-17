/*
 * \file AccountSummary.cs
 * \brief Value Object representing user's bank account summary
 * 
 * \date 17-09-2025
 */

using Entity = Transacto.Domain.Account.Entities.Account;

namespace Transacto.Domain.Account.ValueObjects;

public class AccountSummary
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public DateOnly FromDate { get; private set; }
    public DateOnly ToDate { get; private set; }
    public Entity Account { get; private set; } = default!;
    
    public Money Inflow { get; private set;}
    public Money Outflow { get; private set; }
    public Money NetBalance => Inflow - Outflow;

    public AccountSummary(Money inflow, Money outflow)
    {
        Inflow = inflow;
        Outflow = outflow;
    }
}
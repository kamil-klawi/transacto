/*
 * \file IAccountRepository.cs
 * \brief Account interface representing account repository
 * 
 * \date 17-09-2025
 */

using Transacto.Domain.Account.ValueObjects;
using Entity = Transacto.Domain.Account.Entities.Account;

namespace Transacto.Domain.Account.Repositories;

public interface IAccountRepository
{
    Task<IEnumerable<Entity>> GetAccounts();
    Task<Entity> CreateAccount(Entity account);
    Task<Entity?> GetAccount(Guid id);
    Task UpdateAccount(Entity account);
    Task DeleteAccount(Guid id);
    Task<Money> GetAccountBalance(Guid id);
    Task<AccountSummary> GetAccountSummary(Guid id);
}
/*
 * \file IUserRepository.cs
 * \brief User interface representing user repository
 * 
 * \date 14-09-2025
 */

using Transacto.Domain.Users.Entities;

namespace Transacto.Domain.Users.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}
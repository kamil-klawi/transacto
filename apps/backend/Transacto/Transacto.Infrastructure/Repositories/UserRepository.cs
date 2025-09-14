/*
 * \file UserRepository.cs
 * \brief Implementation of IUserRepository using Entity Framework Core
 * 
 * \date 14-09-2025
 */

using Microsoft.EntityFrameworkCore;
using Transacto.Domain.Users.Entities;
using Transacto.Domain.Users.Repositories;
using Transacto.Infrastructure.Persistence;

namespace Transacto.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await  context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task CreateAsync(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await GetByIdAsync(id);
        if (user == null)
            return;
        
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}
/*
 * \file ApplicationDbContext.cs
 * \brief Entity Framework Core database context for the Transacto application
 *
 * This class defines the main EF Core database context used for persisting
 * and retrieving domain entities
 *
 * \date 14-09-2025
 */

using Microsoft.EntityFrameworkCore;
using Transacto.Domain.Users.Entities;

namespace Transacto.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(builder =>
        {
            builder.OwnsOne(u => u.Email);
            builder.OwnsOne(u => u.PasswordHash);
            builder.OwnsOne(u => u.PersonalData, pd =>
            {
                pd.OwnsOne(p => p.Address);
            });
            builder.OwnsOne(u => u.TwoFactorAuthentication);
        });
    }
}
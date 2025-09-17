/*
 * \file ApplicationDbContext.cs
 * \brief Entity Framework Core database context for the Transacto application
 *
 * This class defines the main EF Core database context used for persisting
 * and retrieving domain entities
 *
 * \date 14-09-2025
 * \updated 17-09-2025
 */

using Microsoft.EntityFrameworkCore;
using Transacto.Domain.Account.Entities;
using Transacto.Domain.Account.ValueObjects;
using Transacto.Domain.Users.Entities;

namespace Transacto.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<AccountSummary> AccountSummaries => Set<AccountSummary>();

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

        modelBuilder.Entity<Account>(builder =>
        {
            builder.OwnsOne(a => a.Balance);
            builder.HasMany(a => a.Summaries).WithOne(a => a.Account);
        });

        modelBuilder.Entity<AccountSummary>();
    }
}
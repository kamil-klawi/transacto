/*
 * \file ApplicationDbContext.cs
 * \brief Entity Framework Core database context for the Transacto application
 *
 * This class defines the main EF Core database context used for persisting
 * and retrieving domain entities
 *
 * \date 14-09-2025
 * \updated 19-09-2025
 */

using Microsoft.EntityFrameworkCore;
using Transacto.Domain.Account.Entities;
using Transacto.Domain.Account.ValueObjects;
using Transacto.Domain.Currency.Entities;
using Transacto.Domain.Transaction.Entities;
using Transacto.Domain.Users.Entities;

namespace Transacto.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<AccountSummary> AccountSummaries => Set<AccountSummary>();
    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<ScheduledTransaction> ScheduledTransactions => Set<ScheduledTransaction>();

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
        
        modelBuilder.Entity<Currency>();
        
        modelBuilder.Entity<Transaction>(builder =>
        {
            builder.HasKey(t => t.Id);
            
            builder.HasOne(t => t.FromAccount)
                .WithMany()
                .HasForeignKey(a => a.FromAccountId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(t => t.ToAccount)
                .WithMany()
                .HasForeignKey(a => a.ToAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Currency)
                .WithMany()
                .HasForeignKey(t => t.CurrencyId);

            builder.HasOne(t => t.ScheduledTransaction)
                .WithMany()
                .HasForeignKey(t => t.ScheduledTransactionId)
                .OnDelete(DeleteBehavior.Restrict);;
        });
        
        modelBuilder.Entity<ScheduledTransaction>(builder =>
        {
            builder.HasKey(st => st.Id);

            builder.HasOne(st => st.User)
                .WithMany()
                .HasForeignKey(st => st.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(st => st.FromAccount)
                .WithMany()
                .HasForeignKey(st => st.FromAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(st => st.ToAccount)
                .WithMany()
                .HasForeignKey(st => st.ToAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(st => st.Currency)
                .WithMany()
                .HasForeignKey(st => st.CurrencyId);
        });
    }
}
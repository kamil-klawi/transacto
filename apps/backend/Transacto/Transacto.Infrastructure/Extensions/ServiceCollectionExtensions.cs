/*
 * \file ServiceCollectionExtensions.cs
 * \brief Extension method for configuring infrastructure services
 *
 * The ServiceCollectionExtensions class provides an extension
 * method for registering infrastructure-level services
 *
 * \date 14-09-2025
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transacto.Domain.Users.Repositories;
using Transacto.Infrastructure.Persistence;
using Transacto.Infrastructure.Repositories;

namespace Transacto.Infrastructure.Extensions;

public class ServiceCollectionExtensions
{
    public static void AddInfrastructure(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
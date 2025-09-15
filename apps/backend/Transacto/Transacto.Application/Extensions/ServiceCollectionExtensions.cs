/*
 * \file ServiceCollectionExtensions.cs
 * \brief Extension methods for configuring application services
 *
 * \date 15-09-2025
 */

using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Transacto.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
        services.AddAutoMapper(_ => {}, typeof(ServiceCollectionExtensions).Assembly);
        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
    }
}
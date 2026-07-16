using eCommerce.Core.ServiceContracts;
using Microsoft.Extensions.DependencyInjection;
using eCommerce.Core.Services;
using FluentValidation;
using eCommerce.Core.Validators;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        // Add services to IoC container
        // Infrastructure services often include data access, caching and other low level task;

        services.AddTransient<IUsersService, UsersService>();

        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

        return services;

    }

}


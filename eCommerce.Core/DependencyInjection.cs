using eCommerce.Core.ServiceContracts;
using Microsoft.Extensions.DependencyInjection;
using eCommerce.Core.Services;
using FluentValidation;
using eCommerce.Core.Validators;
using Microsoft.Graph;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to IoC container
        // Infrastructure services often include data access, caching and other low level task;

        services.AddTransient<IUsersService, UsersService>();

        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

        services.AddScoped<GraphServiceClient>(provider =>
        {
            var scopes = new[] { "https://graph.microsoft.com/.default" };
            var options = new ClientSecretCredentialOptions()
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            var clientSecretCredential = new ClientSecretCredential(
                configuration["AzureEntraID:TenantId"],
                configuration["AzureEntraID:ClientId"],
                configuration["AzureEntraID:ClientSecret"],
                options);

            var graphClient = new GraphServiceClient(clientSecretCredential, scopes);

            return graphClient;

        });

        return services;

    }

}


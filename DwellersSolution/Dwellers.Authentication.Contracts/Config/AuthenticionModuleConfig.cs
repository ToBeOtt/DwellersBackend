using Dwellers.Authentication.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.Authentication.Contracts.Config
{
    public static class AuthenticionModuleConfig
    {
        public static IServiceCollection AddAuthModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthenticationApplicationServices(configuration);
            services.AddAuthenticationInfrastructureServices(configuration);
            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.Authentication.Contracts.Config
{
    public static class AuthenticionModuleConfig
    {
        public static IServiceCollection AddAuthenticationModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthenticationServices(configuration);
            return services;
        }
    }
}

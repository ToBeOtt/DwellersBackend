using Dwellers.DwellerCore.Interfaces;
using Dwellers.DwellerCore.Queries;
using Dwellers.DwellerCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.DwellerCore.Application
{
    public static class DwellerCoreConfiguration
    {
        public static IServiceCollection AddDwellerCoreModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Other services
            services.AddHttpContextAccessor();  

            services.AddTransient<DwellingServices>();
            //services.AddTransient<IDwellerCoreQueries, DwellerCoreQueries>();
         
            return services;
        }
    }
}

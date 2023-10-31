using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dwellers.Offerings.Application.Mappings
{
    public static class HouseholdMappingDependencyInjection
    {
        public static IServiceCollection AddHouseholdModuleMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            return services;
        }
    }
}

using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dwellers.Offerings.Application.Mappings
{
    public static class OfferingsDependencyInjection
    {
        public static IServiceCollection AddOfferingsModuleMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            return services;
        }
    }
}

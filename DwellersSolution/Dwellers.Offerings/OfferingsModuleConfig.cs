using Dwellers.Offerings.Services.DwellerItems;
using Dwellers.Offerings.Services.DwellerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.Offerings
{
    public static class OfferingsModuleConfig
    {
        public static IServiceCollection AddOfferingsModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<DwellerItemCommandService>();
            services.AddTransient<DwellerItemQueryService>();

            services.AddTransient<DwellerServiceCommandService>();
            services.AddTransient<DwellerServiceQueryService>();

            return services;
        }
    }
}

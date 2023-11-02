using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerServices;
using Dwellers.Common.Persistance.OfferingsModule.Repositories.DwellerItems;
using Dwellers.Common.Persistance.OfferingsModule.Repositories.DwellerServices;
using Dwellers.Offerings.Application.Mappings.DwellerItems;
using Dwellers.Offerings.Application.Mappings.DwellerServices;
using Dwellers.Offerings.Application.Services.DwellerItems;
using Dwellers.Offerings.Application.Services.DwellerServices;
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

            services.AddTransient<DwellerItemMappingService>();
            services.AddTransient<DwellerServiceMappingService>();

            return services;
        }
    }
}

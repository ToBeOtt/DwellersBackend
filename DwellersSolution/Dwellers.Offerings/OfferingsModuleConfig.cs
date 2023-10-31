using Dwellers.Offerings.Application.Interfaces.DwellerItems;
using Dwellers.Offerings.Application.Interfaces.DwellerServices;
using Dwellers.Offerings.Application.Services.DwellerItems;
using Dwellers.Offerings.Application.Services.DwellerServices;
using Dwellers.Offerings.Repositories.DwellerItems;
using Dwellers.Offerings.Repositories.DwellerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.Offerings
{
    public static class OfferingsModuleConfig
    {
        public static IServiceCollection AddOfferingsModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDwellerItemCommandRepository, DwellerItemCommandRepository>();
            services.AddTransient<IDwellerItemQueryRepository, DwellerItemQueryRepository>();

            services.AddTransient<IDwellerServiceCommandRepository, DwellerServiceCommandRepository>();
            services.AddTransient<IDwellerServiceQueryRepository, DwellerServiceQueryRepository>();


            services.AddTransient<DwellerItemCommandService>();
            services.AddTransient<DwellerItemQueryService>();

            services.AddTransient<DwellerServiceCommandService>();
            services.AddTransient<DwellerServiceQueryService>();

            return services;
        }
    }
}

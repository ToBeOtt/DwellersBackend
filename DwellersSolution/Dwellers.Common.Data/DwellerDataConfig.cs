using Dwellers.Common.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infrastructure;

namespace Dwellers.Common.Data
{
    public static class DwellerDataConfig
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string not found.");

            services.AddDbContext<DwellerDbContext>(options => options.UseSqlServer(connectionString)
            .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>());

            return services;
        }
    }
}

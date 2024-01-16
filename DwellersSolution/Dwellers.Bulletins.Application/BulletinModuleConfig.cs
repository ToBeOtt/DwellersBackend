using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.Bulletins.Application
{
    public static class BulletinModuleConfig
    {
        public static IServiceCollection AddBulletinModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}

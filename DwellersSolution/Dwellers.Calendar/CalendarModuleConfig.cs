using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.Calendar
{
    public static class CalendarModuleConfig
    {
        public static IServiceCollection AddCalendarModuleServices(this IServiceCollection services, IConfiguration configuration)
        { 
            return services;
        }
    }
}

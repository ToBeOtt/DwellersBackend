using Dwellers.Calendar.Application.Interfaces;
using Dwellers.Calendar.Repositories;
using Dwellers.Common.DAL.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.Calendar
{
    public static class CalendarModuleConfig
    {
        public static IServiceCollection AddCalendarModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDwellerEventsCommandRepository, DwellerEventsCommandRepository>();
            services.AddTransient<IDwellerEventsQueryRepository, DwellerEventsQueryRepository>();

            return services;
        }
    }
}

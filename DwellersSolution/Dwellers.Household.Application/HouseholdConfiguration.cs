using Dwellers.Household.Common.Behaviours;
using Dwellers.Household.Mappings;
using Dwellers.Household.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dwellers.Household.Application
{
    public static class HouseholdConfiguration
    {
        public static IServiceCollection AddHouseholdModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Other services
            services.AddHttpContextAccessor();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //MediatR
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient<HouseServices>();
            services.AddTransient<UserServices>();
            services.AddTransient<HouseRegisterService>();

            services.AddTransient<HouseholdMappingService>();
            
            return services;
        }
    }
}

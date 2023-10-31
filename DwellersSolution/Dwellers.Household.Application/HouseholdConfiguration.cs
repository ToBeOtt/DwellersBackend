using Dwellers.Household.Application.Common.Behaviours;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using Dwellers.Household.Application.Services;
using Dwellers.Household.Infrastructure.Repositories.Houses;
using Dwellers.Household.Infrastructure.Repositories.Users;
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

            //Repositories
            services.AddTransient<IHouseCommandRepository, HouseCommandRepository>();
            services.AddTransient<IHouseQueryRepository, HouseQueryRepository>();
            services.AddTransient<IUserCommandRepository, UserCommandRepository>();
            services.AddTransient<IUserQueryRepository, UserQueryRepository>();

            services.AddTransient<HouseServices>();
            services.AddTransient<UserServices>();

            return services;
        }
    }
}

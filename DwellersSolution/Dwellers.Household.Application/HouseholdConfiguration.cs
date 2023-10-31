using Dwellers.Common.DAL.Context;
using Dwellers.Household.Application.Common.Behaviours;
using Dwellers.Household.Application.Interfaces.Household.DwellerEvents;
using Dwellers.Household.Application.Interfaces.Household.DwellerItems;
using Dwellers.Household.Application.Interfaces.Household.DwellerService;
using Dwellers.Household.Application.Interfaces.Household.Meetings;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using Dwellers.Household.Application.Services;
using Dwellers.Household.Infrastructure.Repositories.DwellerHouse;
using Dwellers.Household.Infrastructure.Repositories.Household.DwellerEvents;
using Dwellers.Household.Infrastructure.Repositories.Household.DwellerItem;
using Dwellers.Household.Infrastructure.Repositories.Household.DwellerService;
using Dwellers.Household.Infrastructure.Repositories.Household.Meetings;
using Dwellers.Household.Infrastructure.Repositories.Users;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dwellers.Household.Application
{
    public static class HouseholdConfiguration
    {
        public static IServiceCollection AddHouseholdModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string not found.");

            // Makes sure this modules DbContext is used 
            services.AddDbContext<DwellerDbContext>(options => options.UseSqlServer(connectionString));

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
            services.AddTransient<INoteCommandRepository, NoteCommandRepository>();
            services.AddTransient<INoteQueryRepository, NoteQueryRepository>();
            services.AddTransient<IDwellerEventsCommandRepository, DwellerEventsCommandRepository>();
            services.AddTransient<IDwellerEventsQueryRepository, DwellerEventsQueryRepository>();
            services.AddTransient<IDwellerItemCommandRepository, DwellerItemCommandRepository>();
            services.AddTransient<IDwellerItemQueryRepository, DwellerItemQueryRepository>();
            services.AddTransient<IDwellerServiceCommandRepository, DwellerServiceCommandRepository>();
            services.AddTransient<IDwellerServiceQueryRepository, DwellerServiceQueryRepository>();
            services.AddTransient<IUserCommandRepository, UserCommandRepository>();
            services.AddTransient<IUserQueryRepository, UserQueryRepository>();

            services.AddTransient<HouseServices>();
            services.AddTransient<UserServices>();

            // SignalR
            services.AddSignalR();

            return services;
        }
    }
}

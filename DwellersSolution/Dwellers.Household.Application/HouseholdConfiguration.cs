using Dwellers.Household.Application.Common.Behaviours;
using Dwellers.Household.Application.Interfaces.Authentication;
using Dwellers.Household.Application.Interfaces.Household.DwellerEvents;
using Dwellers.Household.Application.Interfaces.Household.DwellerItems;
using Dwellers.Household.Application.Interfaces.Household.DwellerService;
using Dwellers.Household.Application.Interfaces.Household.Meetings;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using Dwellers.Household.Domain.Entities;
using Dwellers.Household.Infrastructure.Data;
using Dwellers.Household.Infrastructure.Repositories.Authentication;
using Dwellers.Household.Infrastructure.Repositories.DwellerHouse;
using Dwellers.Household.Infrastructure.Repositories.Household.DwellerEvents;
using Dwellers.Household.Infrastructure.Repositories.Household.DwellerItem;
using Dwellers.Household.Infrastructure.Repositories.Household.DwellerService;
using Dwellers.Household.Infrastructure.Repositories.Household.Meetings;
using Dwellers.Household.Infrastructure.Repositories.Users;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Dwellers.Household.Application
{
    public static class HouseholdConfiguration
    {
        public static IServiceCollection AddHouseholdModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string not found.");

            // Makes sure this modules DbContext is used 
            services.AddDbContext<HouseholdDbContext>(options => options.UseSqlServer());

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

            // SignalR
            services.AddSignalR();

            return services;
        }
        /// <summary>
        /// This method makes sure that my DbContext gets injected in api and used as a separate DBcontext with this 
        /// modules schema.
        /// </summary>
        public class HouseholdDbContextFactory : IDesignTimeDbContextFactory<HouseholdDbContext>
        {
            public HouseholdDbContext CreateDbContext(string[] args)
            {
                // Get the configuration from appsettings.json
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                // Get the connection string from the configuration
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                // Create DbContextOptions using the connection string
                var optionsBuilder = new DbContextOptionsBuilder<HouseholdDbContext>()
                    .UseSqlServer(connectionString);

                // Create the AuthDbContext instance and return it
                return new HouseholdDbContext(optionsBuilder.Options);
            }
        }
    }
}

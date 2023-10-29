using Dwellers.Authentication.Application.Interfaces;
using Dwellers.Authentication.Infrastructure.Data;
using Dwellers.Authentication.Infrastructure.Data.Models;
using Dwellers.Authentication.Infrastructure.Repositories;
using Dwellers.Household.Application.Interfaces.Authentication;
using Dwellers.Household.Infrastructure.Repositories.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dwellers.Authentication.Infrastructure
{
    public static class AuthenticationInfrastructureConfig
    {
        public static IServiceCollection AddAuthenticationInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string not found.");

            // Makes sure this modules DbContext is used 
            services.AddDbContext<AuthDbContext>(options => options.UseSqlServer());

            services.AddDefaultIdentity<DbUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            // Authentication & Tokens
            services.AddAuth(configuration);

            // Other services
            services.AddHttpContextAccessor();

            //Repositories
            services.AddTransient<IRegistrationRepository, RegistrationRepository>();

            return services;
        }

        public class AuthDbContextContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
        {
            public AuthDbContext CreateDbContext(string[] args)
            {
                // Get the configuration from appsettings.json
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                // Get the connection string from the configuration
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                // Create DbContextOptions using the connection string
                var optionsBuilder = new DbContextOptionsBuilder<AuthDbContext>()
                    .UseSqlServer(connectionString);

                // Create the AuthDbContext instance and return it
                return new AuthDbContext(optionsBuilder.Options);
            }
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");

            services.AddSingleton(Options.Create(jwtSettings));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["SecretKey"])),
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"]
                };
            });

            services.AddTransient<IJwtTokenRepository, JwtTokenRepository>();

            return services;
        }
    }
}

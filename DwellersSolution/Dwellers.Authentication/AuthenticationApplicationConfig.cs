using Dwellers.Authentication.Application.Interfaces;
using Dwellers.Authentication.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Authentication
{
    public static class AuthenticationApplicationConfig
    {
        public static IServiceCollection AddAuthenticationApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<RegistrationService>();
            services.AddTransient<AuthenticationService>();

            return services;
        }
    }
}

using Dwellers.Bulletins.Application.Bulletins.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.Infrastructure.Configuration.Queries;

namespace Dwellers.Bulletins.Application
{
    public static class BulletinModuleConfig
    {
        public static IServiceCollection AddBulletinModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<ICommandHandler<AddSomethingCommand, AddSomethingResult>, TestHandler>();
           
            return services;
        }
    }
}
